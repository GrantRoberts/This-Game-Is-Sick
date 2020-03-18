using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class HealingStation : MonoBehaviour
{
    float m_Timer = 0.0f;
    
    public float m_HealTime = 3;
    
    public float m_HealAmount = 0.3f;

    private Animator m_Anim;

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
        m_Anim.SetBool("Activated", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        m_Anim.SetBool("Activated", true);
    }

    private void OnTriggerStay(Collider other)
    {
        //If the collision object is a player
        if (other.gameObject.tag == "Player")
        {
            //Get the player script
            Player p = other.gameObject.GetComponent<Player>();

            //If they are infected
            if(p.GetInfected())
            {
                //Add to the timer
                m_Timer += Time.deltaTime;

                //if the timer is longer or equal to the heal time
                if (m_Timer >= m_HealTime)
                {
                    //reset the timerd
                    m_Timer = 0;

                    //Heal the player
                    p.SetHealth(p.GetHealth() + m_HealAmount);


                    if(p.GetHealth() <= 0)
                    {
                        p.SetInfected(false);
                        Debug.Log("No longer infected");
                    }
                    //log the health
                    Debug.Log(p.GetHealth());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_Anim.SetBool("Activated", false);
    }
}
