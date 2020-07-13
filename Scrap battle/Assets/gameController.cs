using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameController : MonoBehaviour {

    public static int p0Head, p1Head, p2Head, p3Head;
    public static int p0Wheel, p1Wheel, p2Wheel, p3Wheel;
    public static int p0Weapon, p1Weapon, p2Weapon, p3Weapon;
    public static int PlayerCount=2;
    public static int p0Deaths, p1Deaths, p2Deaths, p3Deaths;
    public Transform[] spawnPoints;
    public GameObject PlayerPrefab;
    public Text p0Text, p1Text, p2Text, p3Text;

    // Use this for initialization
    void Start ()
    {
		for(int i = 0; i < PlayerCount; i++)
        {
            GameObject Player=Instantiate(PlayerPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
            Player.tag = "Player" + i;
        }
	}

    public void SpawnPlayer(int playerNumber)
    {
        int i = Random.Range(0, 4);
        GameObject Player = Instantiate(PlayerPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
        Player.tag = "Player" + playerNumber;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        p0Text.text = "" + p0Deaths;
        p1Text.text = "" + p1Deaths;
        p2Text.text = "" + p2Deaths;
        p3Text.text = "" + p3Deaths;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
    }
}
