using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour {

    public float sensitivity = 1f;

    
    private Vector3 mousePosition;
    private float yRation;

	// Use this for initialization
	void Start () {
        mousePosition = new Vector3(0f, 2f, -3.2f);
        
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = Input.mousePosition;
        yRation = mousePosition.x * sensitivity;

        transform.rotation = Quaternion.Euler(0, yRation, 0);
        
	}


    private void FixedUpdate()
    {
      
    }
}
