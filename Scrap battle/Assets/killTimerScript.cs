using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killTimerScript : MonoBehaviour {

    private float lifeTime = 0;

    public float maxLifeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeTime += Time.deltaTime;
        
        if (lifeTime >= maxLifeTime)
        {
            Destroy(gameObject);
        }	
	}
}
