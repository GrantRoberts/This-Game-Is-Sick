using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
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
                m_Slider.GetComponent<ProgressBar>().IncreaseProgress();
            }
        }
    }
}