using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    private float m_Progress = 0.0f;

    public float m_ProgressSpeed = 0.0f;

    public Slider m_Slider;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Filling");
                m_Progress += m_ProgressSpeed * Time.deltaTime;
                m_Slider.value = m_Progress;
            }
        }
    }
}
