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
    public ProgressBar m_Slider;

    private int m_InputPrompt;

    private bool m_PromptGenerated = false;

    public float m_MistakeTimer = 0.0f;

    public Image[] m_ButtonPromptImages = new Image[4];
    
    /// <summary>
    /// Player can interact with the objective.
    /// </summary>
    /// <param name="other">Object in the trigger.</param>
    private void OnTriggerStay(Collider other)
    {
        if (m_PromptGenerated)
        {
            if (XCI.GetButtonDown(XboxButton.A) && m_InputPrompt == (int)XboxButton.A)
            {
                m_Slider.IncreaseProgress();
                GeneratePrompt();
            }
            else if (XCI.GetButtonDown(XboxButton.B) && m_InputPrompt == (int)XboxButton.B)
            {
                m_Slider.IncreaseProgress();
                GeneratePrompt();
            }
            else if (XCI.GetButtonDown(XboxButton.X) && m_InputPrompt == (int)XboxButton.X)
            {
                m_Slider.IncreaseProgress();
                GeneratePrompt();
            }
            else if (XCI.GetButtonDown(XboxButton.Y) && m_InputPrompt == (int)XboxButton.Y)
            {
                m_Slider.IncreaseProgress();
                GeneratePrompt();
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                // Interacting with the objective.
                if (XCI.GetButton(XboxButton.A))
                {
                    GeneratePrompt();
                    m_PromptGenerated = true;
                }
            }
        }
    }

    private void GeneratePrompt()
    {
        m_InputPrompt = Random.Range(0, 4);
        Debug.Log(m_InputPrompt);
    }
}