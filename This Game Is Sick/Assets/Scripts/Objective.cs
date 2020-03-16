using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    private bool m_PlayerInRadius = false;

    private float m_Progress = 0.0f;

    public float m_ProgressSpeed = 0.0f;

    public Slider m_Slider;

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerInRadius)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Filling");
                m_Progress += m_ProgressSpeed * Time.deltaTime;
                m_Slider.value = m_Progress;
            }
        }
        //else
          //Debug.Log(m_PlayerInRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        m_PlayerInRadius = true;
    }

    private void OnTriggerExit(Collider other)
    {
        m_PlayerInRadius = false;
    }
}
