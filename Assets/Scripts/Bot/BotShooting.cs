using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShooting : MonoBehaviour {

    
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public AudioSource m_ShootingAudio;
    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;


    private float m_FireForce = 35f;
    private float m_ChargeTime = 3f;
    private float m_ChargeSpeed = 1f;
    private float m_CurrentReloadForce;
    private float m_FireDistance = 25f;
    private bool m_Fired;

    public void OnEnable()
    {
        m_CurrentReloadForce = 0f;
        m_Shell.GetComponent<MeshRenderer>().sharedMaterial.color = Color.cyan;
    }
    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.

        Recharging();
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            if (playerInFireZone() && !m_Fired)
            {
                Fire();
                if (m_Fired)
                {
                    m_ShootingAudio.clip = m_ChargingClip;
                    m_ShootingAudio.Play();
                }
            }
        }
            
    }


    private void Fire()
    {
        // Instantiate and launch the shell.
        m_Fired = true;

        Rigidbody shellInstantice = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstantice.velocity = m_FireForce * m_FireTransform.forward;

        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        m_CurrentReloadForce = 0f;
    }

    private void Recharging()
    {
        if (m_Fired)
        {
            m_CurrentReloadForce += m_ChargeSpeed * Time.deltaTime;
            if (m_CurrentReloadForce >= m_ChargeTime)
            {
                m_Fired = false;
            }
        }
    }
    
    private bool playerInFireZone()
    {

        
        Vector3 curBotPos = transform.position;
        Vector3 playerVector = GameObject.FindGameObjectWithTag("Player").transform.position;


        float disToPlayer = (float)Mathf.Sqrt(Mathf.Pow(playerVector.x - curBotPos.x, 2) +
           Mathf.Pow(playerVector.y - curBotPos.y, 2) +
           Mathf.Pow(playerVector.z - curBotPos.z, 2));

        if (disToPlayer <= m_FireDistance)
        {
            return true;
        }else
        {
            return false;
        }

        
    }
}
