using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour {

    public float timeAlive = 0f;

    public LayerMask robotMasks;
    public AudioSource explosionSound;

    public float maxDamage, explosionRadius, explosionForce;

	// Use this for initialization
	void Start ()
    {
        transform.eulerAngles = new Vector3 (0, 1, 0) * Random.Range(0, 359);

        //SoundPlays
        Debug.Log("SoundPlays");


        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, robotMasks);

        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;

            // Add an explosion force.
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

    
            Debug.Log("EXPLOOOOOSION");

            // Find the TankHealth script associated with the rigidbody.
            robotHealth targetHealth = targetRigidbody.GetComponent<robotHealth>();

            // If there is no TankHealth script attached to the gameobject, go on to the next collider.
            if (!targetHealth)
                continue;

            // Calculate the amount of damage the target should take based on it's distance from the shell.
            float damage = CalculateDamage(targetRigidbody.position);

            // Deal this damage to the tank.
            targetHealth.TakeDamage(damage);
        }
        // Play the explosion sound effect.
        //explosionSound.Play();

    }
	
	// Update is called once per frame
	void Update ()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive > 4)
        {
            Destroy(gameObject);
        }

        if (explosionSound.time > 0.5f)
        {
            explosionSound.Stop();
        }
	}


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Create a vector from the shell to the target.
        Vector3 explosionToTarget = targetPosition - transform.position;

        // Calculate the distance from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;

        // Calculate damage as this proportion of the maximum possible damage.
        float damage = relativeDistance * maxDamage;

        // Make sure that the minimum damage is always 0.
        damage = Mathf.Max(0f, damage);

        return damage;
    }
}

