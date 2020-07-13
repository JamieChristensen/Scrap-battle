using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour {
    public Text textObject;
    public GameObject[] p0wheels;
    public GameObject[] p0heads;
    public GameObject[] p0weapons;
    public GameObject[] p1wheels;
    public GameObject[] p1heads;
    public GameObject[] p1weapons;
    public GameObject[] p2wheels;
    public GameObject[] p2heads;
    public GameObject[] p2weapons;
    public GameObject[] p3wheels;
    public GameObject[] p3heads;
    public GameObject[] p3weapons;

    public bool p0Ready = false;
    public bool p1Ready = false;
    public bool p2Ready = false;
    public bool p3Ready = false;

    public int p0Head;
    public int p0Weapon;
    public int p0Wheel;
    public int p0Part;

    public int p1Head;
    public int p1Weapon;
    public int p1Wheel;
    public int p1Part;

    public int p2Head;
    public int p2Weapon;
    public int p2Wheel;
    public int p2Part;

    public int p3Head;
    public int p3Weapon;
    public int p3Wheel;
    public int p3Part;

    public int PlayersReady;

    public GameObject menuTing;

    // Use this for initialization
    void Start () {
        textObject.text = "Players: " + gameController.PlayerCount;

    }
    public void playerPlus()
    {
        if (gameController.PlayerCount < 4)
            gameController.PlayerCount++;
        textObject.text = "Players: " + gameController.PlayerCount;
    }
    public void playerminus()
    {
        if (gameController.PlayerCount > 2)
            gameController.PlayerCount--;
        textObject.text = "Players: " + gameController.PlayerCount;
    }

    public void playersChoosen()
    {
        menuTing.SetActive(false);
        p1Ready = true;
        p0Ready = true;
        if (gameController.PlayerCount > 3)
        {
            p3Ready = true;
        }
         if (gameController.PlayerCount > 2)
        {
            p2Ready = true;
        }
        textObject.text = "Players ready: " +PlayersReady+" / "+ gameController.PlayerCount;
    }
	// Update is called once per frame
	void Update () {

        if (p0Ready == true)
        {
            if (Input.GetAxis("Horizontal0") == 1)
            {

                if (p0Part == 0)
                {
                    if (p0Head >= p0heads.Length-1)
                    {
                        p0Head = 0;
                        p0Change();
                    }
                    else
                    {
                        p0Head++;
                        p0Change();
                    }
                }else if (p0Part == 1)
                {
                    if (p0Weapon >= p0weapons.Length-1)
                    {
                        p0Weapon = 0;
                        p0Change();
                    }
                    else
                    {
                        p0Weapon++;
                        p0Change();
                    }
                }
                else if (p0Part == 2)
                {
                    if (p0Wheel >= p0wheels.Length-1)
                    {
                        p0Wheel = 0;
                        p0Change();
                    }
                    else
                    {
                        p0Wheel++;
                        p0Change();
                    }
                }

            }
            else if (Input.GetAxis("Horizontal0") == -1)
            {
                if (p0Part == 0)
                {
                    if (p0Head == 0)
                    {
                        p0Head = p0heads.Length-1;
                        p0Change();
                    }
                    else
                    {
                        p0Head--;
                        p0Change();
                    }
                }
                else if (p0Part == 1)
                {
                    if (p0Weapon ==0)
                    {
                        p0Weapon = p0weapons.Length-1;
                        p0Change();
                    }
                    else
                    {
                        p0Weapon--;
                        p0Change();
                    }
                }
                else if (p0Part == 2)
                {
                    if (p0Wheel ==0)
                    {
                        p0Wheel = p0wheels.Length-1;
                        p0Change();
                    }
                    else
                    {
                        p0Wheel--;
                        p0Change();
                    }
                }
            }
            else if (Input.GetAxis("Vertical0") == 1)
            {
                if (p0Part == 2)
                {
                    p0Part = 0;
                }else
                {
                    p0Part++;
                }
            }
            else if (Input.GetAxis("Vertical0") == -1)
            {
                if (p0Part == 0)
                {
                    p0Part = 2;
                    StartCoroutine(waitP0());
                }
                else
                {
                    p0Part--;
                    StartCoroutine(waitP0());
                }
            }
            if (Input.GetKeyDown("joystick 1 button 5"))
            {
                done(0);
            }
        }

        if (p1Ready == true)
        {
            if (Input.GetAxis("Horizontal1") == 1)
            {

                if (p1Part == 0)
                {
                    if (p1Head >= p1heads.Length - 1)
                    {
                        p1Head = 0;
                        p1Change();
                    }
                    else
                    {
                        p1Head++;
                        p1Change();
                    }
                }
                else if (p1Part == 1)
                {
                    if (p1Weapon >= p1weapons.Length - 1)
                    {
                        p1Weapon = 0;
                        p1Change();
                    }
                    else
                    {
                        p1Weapon++;
                        p1Change();
                    }
                }
                else if (p1Part == 2)
                {
                    if (p1Wheel >= p1wheels.Length - 1)
                    {
                        p1Wheel = 0;
                        p1Change();
                    }
                    else
                    {
                        p1Wheel++;
                        p1Change();
                    }
                }

            }
            else if (Input.GetAxis("Horizontal1") == -1)
            {
                if (p1Part == 0)
                {
                    if (p1Head == 0)
                    {
                        p1Head = p1heads.Length - 1;
                        p1Change();
                    }
                    else
                    {
                        p1Head--;
                        p1Change();
                    }
                }
                else if (p1Part == 1)
                {
                    if (p1Weapon == 0)
                    {
                        p1Weapon = p1weapons.Length - 1;
                        p1Change();
                    }
                    else
                    {
                        p1Weapon--;
                        p1Change();
                    }
                }
                else if (p1Part == 2)
                {
                    if (p1Wheel == 0)
                    {
                        p1Wheel = p1wheels.Length - 1;
                        p1Change();
                    }
                    else
                    {
                        p1Wheel--;
                        p1Change();
                    }
                }
            }
            else if (Input.GetAxis("Vertical1") == 1)
            {
                if (p1Part == 2)
                {
                    p1Part = 0;
                }
                else
                {
                    p1Part++;
                }
            }
            else if (Input.GetAxis("Vertical1") == -1)
            {
                if (p1Part == 0)
                {
                    p1Part = 2;
                    StartCoroutine(waitP1());
                }
                else
                {
                    p1Part--;
                    StartCoroutine(waitP1());
                }
            }
            if (Input.GetKeyDown("joystick 2 button 5"))
            {
                done(1);
            }
        }
        if (p2Ready == true)
        {
            if (Input.GetAxis("Horizontal2") == 1)
            {

                if (p2Part == 0)
                {
                    if (p2Head >= p2heads.Length - 1)
                    {
                        p2Head = 0;
                        p2Change();
                    }
                    else
                    {
                        p2Head++;
                        p2Change();
                    }
                }
                else if (p2Part == 1)
                {
                    if (p2Weapon >= p2weapons.Length - 1)
                    {
                        p2Weapon = 0;
                        p2Change();
                    }
                    else
                    {
                        p2Weapon++;
                        p2Change();
                    }
                }
                else if (p2Part == 2)
                {
                    if (p2Wheel >= p2wheels.Length - 1)
                    {
                        p2Wheel = 0;
                        p2Change();
                    }
                    else
                    {
                        p2Wheel++;
                        p2Change();
                    }
                }

            }
            else if (Input.GetAxis("Horizontal2") == -1)
            {
                if (p2Part == 0)
                {
                    if (p2Head == 0)
                    {
                        p2Head = p2heads.Length - 1;
                        p2Change();
                    }
                    else
                    {
                        p2Head--;
                        p2Change();
                    }
                }
                else if (p2Part == 1)
                {
                    if (p2Weapon == 0)
                    {
                        p2Weapon = p2weapons.Length - 1;
                        p2Change();
                    }
                    else
                    {
                        p2Weapon--;
                        p2Change();
                    }
                }
                else if (p2Part == 2)
                {
                    if (p2Wheel == 0)
                    {
                        p2Wheel = p2wheels.Length - 1;
                        p2Change();
                    }
                    else
                    {
                        p2Wheel--;
                        p2Change();
                    }
                }
            }
            else if (Input.GetAxis("Vertical2") == 1)
            {
                if (p2Part == 2)
                {
                    p2Part = 0;
                }
                else
                {
                    p2Part++;
                }
            }
            else if (Input.GetAxis("Vertical2") == -1)
            {
                if (p2Part == 0)
                {
                    p2Part = 2;
                    StartCoroutine(waitP2());
                }
                else
                {
                    p2Part--;
                    StartCoroutine(waitP2());
                }
            }
            if (Input.GetKeyDown("joystick 3 button 5"))
            {
                done(2);
            }
        }
        if (p3Ready == true)
        {
            if (Input.GetAxis("Horizontal3") == 1)
            {

                if (p3Part == 0)
                {
                    if (p3Head >= p3heads.Length - 1)
                    {
                        p3Head = 0;
                        p3Change();
                    }
                    else
                    {
                        p3Head++;
                        p3Change();
                    }
                }
                else if (p3Part == 1)
                {
                    if (p3Weapon >= p3weapons.Length - 1)
                    {
                        p3Weapon = 0;
                        p3Change();
                    }
                    else
                    {
                        p3Weapon++;
                        p3Change();
                    }
                }
                else if (p3Part == 2)
                {
                    if (p3Wheel >= p3wheels.Length - 1)
                    {
                        p3Wheel = 0;
                        p3Change();
                    }
                    else
                    {
                        p3Wheel++;
                        p3Change();
                    }
                }

            }
            else if (Input.GetAxis("Horizontal3") == -1)
            {
                if (p3Part == 0)
                {
                    if (p3Head == 0)
                    {
                        p3Head = p3heads.Length - 1;
                        p3Change();
                    }
                    else
                    {
                        p3Head--;
                        p3Change();
                    }
                }
                else if (p3Part == 1)
                {
                    if (p3Weapon == 0)
                    {
                        p3Weapon = p3weapons.Length - 1;
                        p3Change();
                    }
                    else
                    {
                        p3Weapon--;
                        p3Change();
                    }
                }
                else if (p3Part == 2)
                {
                    if (p3Wheel == 0)
                    {
                        p3Wheel = p3wheels.Length - 1;
                        p3Change();
                    }
                    else
                    {
                        p3Wheel--;
                        p3Change();
                    }
                }
            }
            else if (Input.GetAxis("Vertical3") == 1)
            {
                if (p3Part == 2)
                {
                    p3Part = 0;
                }
                else
                {
                    p3Part++;
                }
            }
            else if (Input.GetAxis("Vertical3") == -1)
            {
                if (p3Part == 0)
                {
                    p3Part = 2;
                    StartCoroutine(waitP3());
                }
                else
                {
                    p3Part--;
                    StartCoroutine(waitP3());
                }
            }
            if (Input.GetKeyDown("joystick 4 button 5"))
            {
                done(3);
            }
        }



    }
    IEnumerator waitP0()
    {
        p0Ready = false;
        yield return new WaitForSeconds(0.2f);
        p0Ready = true;
    }
    IEnumerator waitP1()
    {
        p1Ready = false;
        yield return new WaitForSeconds(0.2f);
        p1Ready = true;
    }
    IEnumerator waitP2()
    {
        p2Ready = false;
        yield return new WaitForSeconds(0.2f);
        p2Ready = true;
    }
    IEnumerator waitP3()
    {
        p3Ready = false;
        yield return new WaitForSeconds(0.2f);
        p3Ready = true;
    }
    public void p0Change()
    {
        
        StartCoroutine(waitP0());
        if (p0Part == 0)
        {
            for (int i = 0;i< p0heads.Length ; i++){
                if (i == p0Head)
                {
                    p0heads[i].SetActive(true);
                }
                else
                {
                    p0heads[i].SetActive(false);
                }

            }
        }
        else if(p0Part == 1)
        {
            for (int i = 0; i < p0weapons.Length ; i++)
            {
                if (i == p0Weapon)
                {
                    p0weapons[i].SetActive(true);
                }
                else
                {
                    p0weapons[i].SetActive(false);
                }

            }
        }else if (p0Part == 2)
        {
            for (int i = 0; i < p0wheels.Length ; i++)
            {
                if (i == p0Wheel)
                {
                    p0wheels[i].SetActive(true);
                }
                else
                {
                    p0wheels[i].SetActive(false);
                }

            }
        }
    }
    public void p1Change()
    {

        StartCoroutine(waitP1());
        if (p1Part == 0)
        {
            for (int i = 0; i < p1heads.Length; i++)
            {
                if (i == p1Head)
                {
                    p1heads[i].SetActive(true);
                }
                else
                {
                    p1heads[i].SetActive(false);
                }

            }
        }
        else if (p1Part == 1)
        {
            for (int i = 0; i < p1weapons.Length; i++)
            {
                if (i == p1Weapon)
                {
                    p1weapons[i].SetActive(true);
                }
                else
                {
                    p1weapons[i].SetActive(false);
                }

            }
        }
        else if (p1Part == 2)
        {
            for (int i = 0; i < p1wheels.Length; i++)
            {
                if (i == p1Wheel)
                {
                    p1wheels[i].SetActive(true);
                }
                else
                {
                    p1wheels[i].SetActive(false);
                }

            }
        }
    }
    public void p2Change()
    {

        StartCoroutine(waitP2());
        if (p2Part == 0)
        {
            for (int i = 0; i < p2heads.Length; i++)
            {
                if (i == p2Head)
                {
                    p2heads[i].SetActive(true);
                }
                else
                {
                    p2heads[i].SetActive(false);
                }

            }
        }
        else if (p2Part == 1)
        {
            for (int i = 0; i < p2weapons.Length; i++)
            {
                if (i == p2Weapon)
                {
                    p2weapons[i].SetActive(true);
                }
                else
                {
                    p2weapons[i].SetActive(false);
                }

            }
        }
        else if (p2Part == 2)
        {
            for (int i = 0; i < p2wheels.Length; i++)
            {
                if (i == p2Wheel)
                {
                    p2wheels[i].SetActive(true);
                }
                else
                {
                    p2wheels[i].SetActive(false);
                }

            }
        }
    }
    public void p3Change()
    {

        StartCoroutine(waitP3());
        if (p3Part == 0)
        {
            for (int i = 0; i < p3heads.Length; i++)
            {
                if (i == p3Head)
                {
                    p3heads[i].SetActive(true);
                }
                else
                {
                    p3heads[i].SetActive(false);
                }

            }
        }
        else if (p3Part == 1)
        {
            for (int i = 0; i < p3weapons.Length; i++)
            {
                if (i == p3Weapon)
                {
                    p3weapons[i].SetActive(true);
                }
                else
                {
                    p3weapons[i].SetActive(false);
                }

            }
        }
        else if (p3Part == 2)
        {
            for (int i = 0; i < p3wheels.Length; i++)
            {
                if (i == p3Wheel)
                {
                    p3wheels[i].SetActive(true);
                }
                else
                {
                    p3wheels[i].SetActive(false);
                }

            }
        }
    }
    public void done(int playerNR)
    {
        if (playerNR == 0)
        {
            p0Ready = false;
            gameController.p0Head = p0Head;
            gameController.p0Weapon = p0Weapon;
            gameController.p0Wheel = p0Wheel;
            PlayersReady++;

        }else if (playerNR == 1)
        {
            p1Ready = false;
            gameController.p1Head = p1Head;
            gameController.p1Weapon = p1Weapon;
            gameController.p1Wheel = p1Wheel;
            PlayersReady++;

        }
        else if (playerNR == 2)
        {
            p2Ready = false;
            gameController.p2Head = p2Head;
            gameController.p2Weapon = p2Weapon;
            gameController.p2Wheel = p2Wheel;
            PlayersReady++;

        }
        else if (playerNR == 3)
        {
            p3Ready = false;
            gameController.p3Head = p3Head;
            gameController.p3Weapon = p3Weapon;
            gameController.p3Wheel = p3Wheel;
            PlayersReady++;

        }
        textObject.text = "Players ready: " + PlayersReady + " / " + gameController.PlayerCount;
        if (gameController.PlayerCount == PlayersReady)
        {
            SceneManager.LoadScene("battlearena", LoadSceneMode.Single);
        }
    }

}
