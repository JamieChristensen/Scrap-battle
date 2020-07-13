using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour {

    //Add in inspector
    public GameObject projectilePrefab;
    public GameObject rocketTrailPrefab;
    public Transform[] projectileSpawn;

    public GameObject gattlingSparkPrefab;
    public Shader myGatlingShader;
    public LayerMask gatlingNoHitMask;
    public float gatlingKnockback;
    public AudioSource gatlingGunSound;

    public bool shotReady = true;

    public int ammo = 4;

    public float minigunCounter = 0;

    //Skal ændres ved scale-ændring, forskyder raket-spawns

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {

        if(Input.GetKeyUp("joystick " + (transform.parent.GetComponent<playerController>().playerNumber + 1) + " button 5") && gatlingGunSound.isPlaying)
        {
            gatlingGunSound.Stop();
        }
       
	}

    public void weaponShoot(int selectedWeapon)
    {
        if (selectedWeapon == 0 && shotReady && ammo > 0 && Input.GetKeyDown("joystick " + (transform.parent.GetComponent<playerController>().playerNumber + 1) + " button 5"))
        {
            //Bazooka
            //Legacy int:
            //int thisSpawn = Random.Range(0, projectileSpawn.Length);

            for (int i = 0; i < projectileSpawn.Length; i++)
            {
                GameObject rpgInstance = Instantiate(projectilePrefab, projectileSpawn[i].position, projectileSpawn[i].rotation);
                rpgInstance.transform.SetParent(null);
                GameObject rocketTrailInstance = Instantiate(rocketTrailPrefab, rpgInstance.transform.position, rpgInstance.transform.rotation);
                rocketTrailInstance.transform.SetParent(null);

                rpgInstance.GetComponent<bazookaMissileScript>().missileTrail = rocketTrailInstance;
                
            }

            ammo -= 1;

                //Waittime for reload
                if (ammo < 4)
                {
                    StartCoroutine(delay(1.5f, ammo));
                }
                


        }
        else if (selectedWeapon == 1 && Input.GetKey("joystick " + (transform.parent.GetComponent<playerController>().playerNumber + 1) + " button 5"))
        {

            minigunCounter += Time.deltaTime;

            if (!gatlingGunSound.isPlaying)
            {
                gatlingGunSound.Play();
            }
            

            while (minigunCounter > 0.1f)
            {


                for (int i = 0; i < projectileSpawn.Length; i++)
                {
                    //Kan justeres
                    Vector3 randomVector = new Vector3(Random.Range(-20f, 20f), Random.Range(-5f, 5f), 0f);

                    

                    RaycastHit hit;

                    if (Physics.Raycast(projectileSpawn[i].position, transform.parent.forward*100 + randomVector, out hit))
                    {
                        Debug.Log(hit.collider.gameObject.tag + " was hit by RAY!");
                        //Debug.DrawLine(projectileSpawn[i].position, hit.point, Color.red);
                        DrawLine(projectileSpawn[i].position, hit.point);

                        Vector3 forceVector = (projectileSpawn[i].position - hit.point).normalized * -gatlingKnockback;

                        

                        for (int j = 0; j < 4; j++)
                        {
                            if (hit.collider.tag == ("Player" + j))
                            {
                                hit.collider.GetComponent<Rigidbody>().AddForce(forceVector, ForceMode.Force);

                                robotHealth targetHealth = hit.collider.GetComponent<robotHealth>();

                                targetHealth.TakeDamage(70f);
                                

                                Debug.Log("Player" + j + "took " + targetHealth.health + " damage");
                            }
                        }

                        Instantiate(gattlingSparkPrefab, hit.point, Quaternion.identity);
                    }

                    transform.parent.GetComponent<Rigidbody>().AddForce(((projectileSpawn[i].position - hit.point).normalized)*15);



                }

                minigunCounter -= 0.05f;
            }

            
            
        }
        else if (selectedWeapon == 2)
        {

        }
        else if (selectedWeapon == 3)
        {

        }
    }

    public IEnumerator delay (float delayTime, int currentAmmo)
    {


        if (ammo == 0)
        {
            shotReady = false;
        }
        
        yield return new WaitForSeconds(delayTime);

        if (currentAmmo == ammo)
        {
            ammo = 4;
            shotReady = true;
        }
        
    }

void DrawLine(Vector3 start, Vector3 end, float duration = 0.05f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));


        lr.startColor = Color.yellow;
        lr.endColor = Color.yellow;
        //lr.colorGradient = somefloat;

        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        
        //lr.widthCurve
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
