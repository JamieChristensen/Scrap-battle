using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;                 
    public float m_ScreenEdgeBuffer = 4f;           
    public float m_MinSize = 6.5f;                  
    public List<Transform> playerTransforms; 


    private Camera m_Camera;                        
    public float m_ZoomSpeed;                      
    public Vector3 m_MoveVelocity;                 
    public Vector3 m_DesiredPosition;
    public gameController controllerScript;        


    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        findPlayers();
    }

    private void FixedUpdate()
    {
        findPlayers();
        Move();
        Zoom();


    }


    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < playerTransforms.Count; i++)
        {
            if (!playerTransforms[i].gameObject.activeSelf)
                continue;

            averagePos += playerTransforms[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        m_DesiredPosition = averagePos;
    }


    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize -15, ref m_ZoomSpeed, m_DampTime);
    }


    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

        float size = 0f;

        for (int i = 0; i < playerTransforms.Count; i++)
        {
            if (!playerTransforms[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(playerTransforms[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));

            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
        }
        
        size += m_ScreenEdgeBuffer;

        size = Mathf.Max(size, m_MinSize);

        return size;
    }


    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = m_DesiredPosition;

        m_Camera.orthographicSize = FindRequiredSize();
    }

    public void findPlayers()
    {
        playerTransforms.RemoveAll(Transform => Transform == null);
        for (int i = 0; i < gameController.PlayerCount; i++)
        {
            if (GameObject.FindGameObjectWithTag("Player" + i) != null)
            {
                if (!playerTransforms.Contains(GameObject.FindGameObjectWithTag("Player" + i).transform))
                {
                    playerTransforms.Add(GameObject.FindGameObjectWithTag("Player" + i).transform);
                }
            }else
            {
                controllerScript.SpawnPlayer(i);
            }
            
            
        }

        playerTransforms.RemoveAll(Transform => Transform == null);
    }


    /*
     int playersAlive = 0;

        if (GameObject.FindGameObjectWithTag("Player0"))
        {
            playersAlive++;
        }
        

        if (GameObject.FindGameObjectWithTag("Player1"))
        {
            playersAlive++;
        }

        if (GameObject.FindGameObjectWithTag("Player2"))
        {
            playersAlive++;
        }

        if (GameObject.FindGameObjectWithTag("Player3"))
        {
            playersAlive++;
        }

        Transform[] transformArray = new Transform[playersAlive];

        //Det skulle gøres..

        for(int i = 0; i < playersAlive; i++)
        {
            if (GameObject.FindGameObjectWithTag("Player" + i).transform)
            {
                transformArray[i] = GameObject.FindGameObjectWithTag("Player" + i).transform;
                
            }
        }

        /*

        if (GameObject.FindGameObjectWithTag("Player0"))
        {
            transformArray[0] = GameObject.FindGameObjectWithTag("Player0").transform;

            
        }

        if (GameObject.FindGameObjectWithTag("Player1"))
          {
              transformArray[1] = GameObject.FindGameObjectWithTag("Player1").transform;

          }

          if (GameObject.FindGameObjectWithTag("Player2"))
          {
              transformArray[2] = GameObject.FindGameObjectWithTag("Player2").transform;

          }

          if (GameObject.FindGameObjectWithTag("Player3"))
          {
              transformArray[3] = GameObject.FindGameObjectWithTag("Player3").transform;

          }

    playerTransforms = transformArray;
      
     */
}