using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour {
    public float disToPlayer;

    private Transform player;
    // private float minDistance = 5f;
    private NavMeshAgent nav;
    private TankHealth playerHealth;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<TankHealth>();
        nav = GetComponent<NavMeshAgent>();
    }
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        
        if(playerHealth.m_CurrentHealth > 0) { 
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
