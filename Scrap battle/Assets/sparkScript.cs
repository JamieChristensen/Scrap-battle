using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparkScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
         StartCoroutine(DestroySpark());
	}
	
    IEnumerator DestroySpark()
    {
        yield return new WaitForSeconds(0.55f);
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
