using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;            
    public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;     
    public AudioClip m_FireClip;


    private float m_FireForce = 35f;
    private float m_ChargeTime = 3f;
    private float m_ChargeSpeed = 1f;
    private float m_CurrentReloadForce;         
    private bool m_Fired;

    public void OnEnable()
    {
        m_CurrentReloadForce = 0f;
        m_Shell.GetComponent<MeshRenderer>().sharedMaterial.color = Color.blue;
    }
    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.

        Recharging();
        ShellColor();
               if( Input.GetMouseButtonDown(0) && !m_Fired )
           {
               Fire();

           }
           else if(Input.GetMouseButtonUp(0) && m_Fired)
           {

               m_ShootingAudio.clip = m_ChargingClip;
               m_ShootingAudio.Play();
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
            if(m_CurrentReloadForce >= m_ChargeTime)
            {
                m_Fired = false;
            }
        }
    }
    private void ShellColor()
    {
        
        if (Input.GetButtonDown("Shell1"))
        {
            m_Shell.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
        }
        else if (Input.GetButtonDown("Shell2"))
        {
            m_Shell.GetComponent<MeshRenderer>().sharedMaterial.color = Color.blue;
        }
        else if (Input.GetButtonDown("Shell3"))
        {
            m_Shell.GetComponent<MeshRenderer>().sharedMaterial.color = Color.yellow;
        }
    }
}