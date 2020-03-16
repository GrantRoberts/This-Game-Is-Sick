using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool m_Infected;
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
    }
}
