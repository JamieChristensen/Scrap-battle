using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public Rigidbody playerRB;

    public int playerNumber;

    public string horizontalAxis;
    public string verticalAxis;


    //Input Handlers:
    public float turnValue;
    public float movementValue;


    //Movement modifiers
    public float movementSpeed;
    public int maxSpeed;
    public int turnSpeed;
    public bool knockback = false;


    //Components of robots, add in inspector.
    public GameObject[] wheels;
    public GameObject[] heads;
    public GameObject[] weapons;

    //Selected components
    public int selectedWheel;
    public int selectedHead;
    public int selectedWeapon;
    public weaponScript weaponComponent;



    // Use this for initialization
    void Start ()
    {
        initializePlayer();
        Debug.Log("Player Start");

        
    }
  
	
	// Update is called once per frame
	void Update ()
    {
        turnValue = Input.GetAxis(horizontalAxis);
        movementValue = Input.GetAxis(verticalAxis);

        shoot();

        /*
        if (Input.GetKey("joystick " + (playerNumber + 1) + " button 5"))
        {
            shoot();
        }
        */

        if (Input.GetKeyDown("joystick " + (playerNumber + 1) + " button 4"))
        {
            special();
        }
    }

    void FixedUpdate ()
    {
        if (turnValue > 0.2 || turnValue < -0.2)
        {
            transform.eulerAngles += new Vector3(0, turnSpeed * turnValue, 0);
        }
        if (movementValue != 0)
        {
            if (playerRB.velocity.magnitude < maxSpeed || knockback)
            {
                playerRB.AddForce(transform.forward * movementValue * movementSpeed);

                //Debug.Log("Player " + playerNumber + " velocity: " + playerRB.velocity.magnitude);
            }
        }

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    void shoot()
    {
        weaponComponent.weaponShoot(selectedWeapon);
    }

    void special()
    {
        Debug.Log("Special pressed"+playerNumber);
    }




    void initializePlayer()
    {
        playerRB = GetComponent<Rigidbody>();
        if (gameObject.tag == "Player0")
        {
            playerNumber = 0;
            wheels[gameController.p0Wheel].SetActive(true);
            heads[gameController.p0Head].SetActive(true);
            weapons[gameController.p0Weapon].SetActive(true);

            selectedHead = gameController.p0Head;
            selectedWheel = gameController.p0Wheel;
            selectedWeapon = gameController.p0Weapon;
            weaponComponent = weapons[gameController.p0Weapon].GetComponent<weaponScript>();
        }
        else if (gameObject.tag == "Player1")
        {
            playerNumber = 1;
            wheels[gameController.p1Wheel].SetActive(true);
            heads[gameController.p1Head].SetActive(true);
            weapons[gameController.p1Weapon].SetActive(true);

            selectedHead = gameController.p1Head;
            selectedWheel = gameController.p1Wheel;
            selectedWeapon = gameController.p1Weapon;
            weaponComponent = weapons[gameController.p1Weapon].GetComponent<weaponScript>();
        }
        else if (gameObject.tag == "Player2")
        {
            playerNumber = 2;
            wheels[gameController.p2Wheel].SetActive(true);
            heads[gameController.p2Head].SetActive(true);
            weapons[gameController.p2Weapon].SetActive(true);

            selectedHead = gameController.p2Head;
            selectedWheel = gameController.p2Wheel;
            selectedWeapon = gameController.p2Weapon;
            weaponComponent = weapons[gameController.p2Weapon].GetComponent<weaponScript>();
        }
        else if (gameObject.tag == "Player3")
        {
            playerNumber = 3;
            wheels[gameController.p3Wheel].SetActive(true);
            heads[gameController.p3Head].SetActive(true);
            weapons[gameController.p3Weapon].SetActive(true);

            selectedHead = gameController.p3Head;
            selectedWheel = gameController.p3Wheel;
            selectedWeapon = gameController.p3Weapon;
            weaponComponent = weapons[gameController.p3Weapon].GetComponent<weaponScript>();
        }
        horizontalAxis = "Horizontal" + playerNumber;
        verticalAxis = "Vertical" + playerNumber;

        weaponComponent = weapons[selectedWeapon].GetComponent<weaponScript>();
    }

}
