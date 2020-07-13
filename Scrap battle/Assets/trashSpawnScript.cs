using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashSpawnScript : MonoBehaviour {

    public GameObject trashPrefab;

    public int totalDeaths = 0;
    public int theInt = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        totalDeaths = gameController.p0Deaths + gameController.p1Deaths + gameController.p2Deaths + gameController.p3Deaths;


        if (10*theInt == totalDeaths)
        {
            spawnTrash();
            
        }
	}

    void spawnTrash()
    {
        Instantiate(trashPrefab, transform.position, Quaternion.Euler(0, Random.Range(-5f, 5f), 0));
        theInt++;
    }
}
