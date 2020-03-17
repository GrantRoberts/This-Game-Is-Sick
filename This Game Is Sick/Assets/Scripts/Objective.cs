﻿using System.Collections;
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

    /// <summary>
    /// What button the player should press.
    /// </summary>
    private int m_InputPrompt;

    /// <summary>
    /// If a prompt has been generated.
    /// </summary>
    private bool m_PromptGenerated = false;

    /// <summary>
    /// Timer for when a player makes a mistake.
    /// </summary>
    public float m_MistakeTimer = 0.0f;

    /// <summary>
    /// For resetting the timer.
    /// </summary>
    private float m_MistakeTimerMax = 0.0f;

    /// <summary>
    /// Disable player input if the last input was a mistake.
    /// </summary>
    private bool m_DisableInput = false;

    /// <summary>
    /// Images for button prompts.
    /// </summary>
    public Image[] m_ButtonPromptImages = new Image[4];

    /// <summary>
    /// The player in the area.
    /// </summary>
    private XboxController m_CurrentPlayer;

    private void Awake()
    {
        m_MistakeTimerMax = m_MistakeTimer;
    }

    /// <summary>
    /// Update.
    /// </summary>
    private void Update()
    {
        if (m_DisableInput)
        {
            m_MistakeTimer -= Time.deltaTime;
            if (m_MistakeTimer < 0.0f)
            {
                m_MistakeTimer += m_MistakeTimerMax;
                m_DisableInput = false;
            }
            Debug.Log(m_MistakeTimer);
        }
    }

    /// <summary>
    /// Player enters the area.
    /// </summary>
    /// <param name="other">Other object.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_CurrentPlayer = other.GetComponent<Movement>().m_PlayerNumber;
        }
    }

    /// <summary>
    /// Player can interact with the objective.
    /// </summary>
    /// <param name="other">Other object.</param>
    private void OnTriggerStay(Collider other)
    {
        if (!m_DisableInput)
        {
            // If the player has pressed any buttons.
            // Has to be a function, XInput has no way of checking any input.
            if (AnyButtonPressed())
            {
                if (m_PromptGenerated)
                {
                    // Check if the player pressed the button corresponding with the prompt.
                    if (XCI.GetButtonDown(XboxButton.A, m_CurrentPlayer) && m_InputPrompt == (int)XboxButton.A)
                    {
                        m_Slider.IncreaseProgress();
                        GeneratePrompt();
                    }
                    else if (XCI.GetButtonDown(XboxButton.B, m_CurrentPlayer) && m_InputPrompt == (int)XboxButton.B)
                    {
                        m_Slider.IncreaseProgress();
                        GeneratePrompt();
                    }
                    else if (XCI.GetButtonDown(XboxButton.X, m_CurrentPlayer) && m_InputPrompt == (int)XboxButton.X)
                    {
                        m_Slider.IncreaseProgress();
                        GeneratePrompt();
                    }
                    else if (XCI.GetButtonDown(XboxButton.Y, m_CurrentPlayer) && m_InputPrompt == (int)XboxButton.Y)
                    {
                        m_Slider.IncreaseProgress();
                        GeneratePrompt();
                    }
                    // Else the player made a mistake, disable input, the timer will count down in Update.
                    else
                    {
                        m_DisableInput = true;
                        m_PromptGenerated = false;
                    }
                }
                // If a prompt hasn't been generated, if the player presses the A button, generate a prompt.
                else
                {
                    if (other.gameObject.tag == "Player")
                    {
                        // Interacting with the objective.
                        if (XCI.GetButtonDown(XboxButton.A))
                        {
                            GeneratePrompt();
                            m_PromptGenerated = true;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// If player leaves.
    /// </summary>
    /// <param name="other">Other object.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            m_PromptGenerated = false;
    }

    /// <summary>
    /// Generate a prompt for the player.
    /// </summary>
    private void GeneratePrompt()
    {
        m_InputPrompt = Random.Range(0, 4);
        Debug.Log(m_InputPrompt);
    }

    /// <summary>
    /// Check all face buttons to see if one has been pressed by the player.
    /// </summary>
    /// <returns>If a face button has been pressed.</returns>
    private bool AnyButtonPressed()
    {
        for (int i = 0; i < 4; ++i)
        {
            if (XCI.GetButtonDown((XboxButton)i))
            {
                return true;
            }
        }
        return false;
    }
}