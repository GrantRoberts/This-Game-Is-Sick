using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    bool m_Infected = false;
    float m_Health = 1;
    Material m_Shader;

    private void Awake()
    {
        //m_Shader = GetComponentInChildren<Material>();
        m_Shader = transform.GetChild(0).GetComponent<Renderer>().material;
       if(m_Shader == null)
        {
            Debug.Log("m_Shader is null");
        }
        else
        {
            Debug.Log("m_Shader is not null");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //m_Health += 1.0f * Time.deltaTime;
        m_Shader.SetFloat("Vector1_33F9B192",m_Health);
        
       
    }



    //------------------------------------------------------------
    //DO NOT REMOVE FUNCTION. REQUIRED FOR UNITY TO WORK. DO NOT TOUCH!!!!!!!!!
    //------------------------------------------------------------
    public void SetInfected(bool infected)
    {
        m_Infected = infected;

        if (m_Infected)
        {
            m_Health = 0;
        }
    }


    public void SetHealth(float health)
    {
        m_Health = health;
        
        if(m_Health < 0)
        {
            m_Health = 0;
        }
        else if(m_Health > 1)
        {
            m_Health = 1;
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
