using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    bool m_Infected = false;
    float m_Health = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }



    //------------------------------------------------------------
    //DO NOT REMOVE FUNCTION. REQUIRED FOR UNITY TO WORK. DO NOT TOUCH!!!!!!!!!
    //------------------------------------------------------------
    public void SetInfected(bool infected)
    {
        m_Infected = infected;

        if (m_Infected)
        {
            m_Health = 1;
        }
    }


    public void SetHealth(float health)
    {
        m_Health = health;
        
        if(m_Health < 0)
        {
            m_Health = 0;
        }
    }

    public float GetHealth()
    {
        return m_Health;
    }

    public bool GetInfected()
    {
        return m_Infected;
    }
}
