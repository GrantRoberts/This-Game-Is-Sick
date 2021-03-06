﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class HealingStation : MonoBehaviour
{
 
    public float m_HealPerSec = 0.3f;
    Animator m_Anim;
    // Update is called once per frame
    void Update()
    {
        m_Anim = GetComponent<Animator>();
        m_Anim.SetBool("Activated", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
               
                    //Heal the player
                    p.SetHealth(p.GetHealth() + m_HealPerSec * Time.deltaTime);


                    if(p.GetHealth() >= 1.0f)
                    {
                        p.SetInfected(false);
                        Debug.Log("No longer infected");
                    }
                    //log the health
                    Debug.Log(p.GetInfected());
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_Anim.SetBool("Activated", false);
    }
}
