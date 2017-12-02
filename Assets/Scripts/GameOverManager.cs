using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public TankHealth playerHealth;
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;

    private void Awake()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update ()
    {
        if (playerHealth.m_CurrentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
            if(restartTimer>= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel);

                //SceneManager.LoadScene(SceneManager.sceneLoaded);
            }
        }	
	}
}
