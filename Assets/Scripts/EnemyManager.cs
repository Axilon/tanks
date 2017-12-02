using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyManager : MonoBehaviour {
    public TankHealth playerHealth;
    public GameObject enemy;
    public int maxEnemyCount = 10;
    public static int curEnemyCount;
    public float spawnTime = 3f;
    
    
    public Transform[] spawnPoints;
   
    private void Awake()
    {
        curEnemyCount = 0;
    }
    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    private void Spawn()
    {
        //playerHealth = player.GetComponent<TankHealth>();
        if(playerHealth.m_CurrentHealth <= 0f)
        {
            return;
        }

        if (curEnemyCount < maxEnemyCount)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            curEnemyCount++;
        }
        
    }
    

	
}
