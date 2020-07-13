using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robotHealth : MonoBehaviour {

    public GameObject deathExplosion;
    public float health;
    public float StartHealth;
    public Slider HealthBar;
    public Image HealthFill;
    public Light robotLight;

	// Use this for initialization
	void Start ()
    {
        StartHealth = health;

        if (gameObject.tag == "Player0")
        {
            HealthFill.color = Color.red;
            robotLight.color = Color.red;
        }else if (gameObject.tag == "Player1")
        {
            HealthFill.color = Color.blue;
            robotLight.color = Color.blue;
        }
        else if (gameObject.tag == "Player2")
        {
            HealthFill.color = Color.green;
            robotLight.color = Color.green;
        }
        else if (gameObject.tag == "Player3")
        {
            HealthFill.color = Color.yellow;
            robotLight.color = Color.yellow;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
		if (health <= 0)
        {
            GameObject deathExplodeInstance = Instantiate(deathExplosion, transform.position, Quaternion.identity);

            deathExplodeInstance.transform.localScale = new Vector3(3, 3, 3);


            if (gameObject.tag=="Player0") {
                gameController.p0Deaths++;
            }
            else if(gameObject.tag == "Player1") {
                gameController.p1Deaths++;
            }else if (gameObject.tag == "Player2")
            {
                gameController.p2Deaths++;
            }
            else if (gameObject.tag == "Player3")
            {
                gameController.p3Deaths++;
            }
            
                Destroy(gameObject);
        }
        HealthBar.value = (health / StartHealth) * 100;
        
	}

    public void TakeDamage(float damage)
    {
        health -= damage;

        Debug.Log("took " + damage + " damage");
    }
}
