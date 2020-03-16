using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class Objective : MonoBehaviour
{
    /// <summary>
    /// The slider that is the progress bar.
    /// </summary>
    public Slider m_Slider;

    /// <summary>
    /// Player can interact with the objective.
    /// </summary>
    /// <param name="other">Object in the trigger.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Interacting with the objective.
            if (XCI.GetButton(XboxButton.A))
            {
                //Debug.Log("Filling");
                m_Slider.GetComponent<ProgressBar>().IncreaseProgress();
            }
        }
    }
}