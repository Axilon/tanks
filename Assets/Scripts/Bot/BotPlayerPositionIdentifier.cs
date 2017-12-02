using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPlayerPositionIdentifier : MonoBehaviour {
    private GameObject player;
    private Transform playerPosition;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	// Update is called once per frame
	void Update () {
       playerPosition = player.transform;

        Vector3 curPos = playerPosition.position - transform.position;
        curPos.y = 0f;

        Quaternion rotation = Quaternion.LookRotation(curPos, Vector3.up);

        transform.rotation= rotation;
       
    }
}
