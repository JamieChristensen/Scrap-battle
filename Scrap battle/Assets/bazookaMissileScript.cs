using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bazookaMissileScript : MonoBehaviour {

    public Rigidbody missileRB;
    public GameObject missileExplosion;
    public GameObject missileTrail;

    public float missileVelocity;

    public float lifeTime = 0;

	// Use this for initialization
	void Start ()
    {
        //missileRB.AddForce(-transform.forward * missileVelocity);
        missileRB.velocity = -transform.forward * missileVelocity;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //missileRB.AddForce(transform.forward * missileSpeed);

        lifeTime += Time.deltaTime;

        if (lifeTime > 6)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter (Collider other)
    {



        GameObject explosionInstance = Instantiate(missileExplosion, transform.position, Quaternion.identity);
        
        if (other.gameObject.layer == 9)
        {
            Debug.Log("missile hit player");

            other.attachedRigidbody.AddForce(new Vector3(missileRB.velocity.x, 0, missileRB.velocity.y), ForceMode.Impulse);
        }


        Debug.Log("Collision with object");

        Destroy(missileTrail);
        Destroy(gameObject);
    }
}
