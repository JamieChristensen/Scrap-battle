using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTriggerScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player0"))
        {
            robotHealth health = other.GetComponent<robotHealth>();
            health.TakeDamage(10000);
        }


        if (other.CompareTag("Player1"))
        {
            robotHealth health = other.GetComponent<robotHealth>();
            health.TakeDamage(10000);
        }

        if (other.CompareTag("Player2"))
        {
            robotHealth health = other.GetComponent<robotHealth>();
            health.TakeDamage(10000);
        }

        if (other.CompareTag("Player3"))
        {
            robotHealth health = other.GetComponent<robotHealth>();
            health.TakeDamage(10000);
        }

        if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject);
        }
    }
}
