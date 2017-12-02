using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRotation : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 relativePos = (target.position + new Vector3(0,2,0)) - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
        /*transform.LookAt(target);*/
     
	}
}
