using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    /// <summary>
    /// Progress of the bar.
    /// </summary>
    private float m_Progress = 0.0f;

    /// <summary>
    /// How fast the progress bar increases.
    /// </summary>
    public float m_ProgressSpeed = 0.0f;

    /// <summary>
    /// The slider that is the progress bar.
    /// </summary>
    public Slider m_Slider;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Interacting with the objective.
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Filling");
                // Increase the progress by the speed by delta time.
                m_Progress += m_ProgressSpeed * Time.deltaTime;
                // Set the bar's value.
                m_Slider.value = m_Progress;
            }
        }
    }
}