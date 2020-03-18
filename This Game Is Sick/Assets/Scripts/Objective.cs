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
    public Sprite[] m_ButtonPromptImages = new Sprite[4];

    /// <summary>
    /// The player in the area.
    /// </summary>
    private XboxController m_CurrentPlayer;

    /// <summary>
    /// The image prompt on the objective.
    /// </summary>
    private Image m_Prompt;

    public SoundBucket m_SoundBucket;

    private AudioSource m_AudioSource;

    private Animator m_Anim;

    /// <summary>
    /// On startup.
    /// </summary>
    private void Awake()
    {
        // For resetting the timer.
        m_MistakeTimerMax = m_MistakeTimer;

        // Get the prompt image object.
        m_Prompt = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        m_Prompt.gameObject.SetActive(false);

        m_AudioSource = gameObject.GetComponent<AudioSource>();

        m_Anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Update.
    /// </summary>
    private void Update()
    {
        // If input is disabled, a player made a mistake.
        // Decrease the timer and if the timer reaches 0, reset.
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
        if (!m_DisableInput)
        {
            if (other.gameObject.tag == "Player")
            {
                m_CurrentPlayer = other.GetComponent<Movement>().m_PlayerNumber;
                m_Prompt.gameObject.SetActive(true);
                m_AudioSource.clip = m_SoundBucket.m_Sounds[0];
                m_AudioSource.Play();
                m_Anim.SetBool("Activated", true);
            }
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
                    if ((int)GetFaceButtonPress() == m_InputPrompt)
                    {
                        m_Slider.IncreaseProgress();
                        GeneratePrompt();
                        m_AudioSource.clip = m_SoundBucket.m_Sounds[2];
                        m_AudioSource.Play();
                    }
                    // Else the player made a mistake, disable input, the timer will count down in Update.
                    else
                    {
                        m_DisableInput = true;
                        m_PromptGenerated = false;
                        m_Prompt.gameObject.SetActive(false);
                        m_AudioSource.clip = m_SoundBucket.m_Sounds[3];
                        m_AudioSource.Play();
                        m_Anim.SetBool("Activated", false);
                    }
                }
                // If a prompt hasn't been generated, if the player presses the A button, generate a prompt.
                else
                {
                    if (other.gameObject.tag == "Player")
                    {
                        // Interacting with the objective.
                        if (XCI.GetButtonDown(XboxButton.A, m_CurrentPlayer))
                        {
                            GeneratePrompt();
                            m_PromptGenerated = true;
                            m_Anim.SetBool("Activated", true);
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
        {
            m_PromptGenerated = false;
            m_Prompt.sprite = m_ButtonPromptImages[0];
            m_Prompt.gameObject.SetActive(false);
            if (!m_DisableInput)
            {
                m_AudioSource.clip = m_SoundBucket.m_Sounds[1];
                m_AudioSource.Play();
            }
            m_Anim.SetBool("Activated", false);
        }
    }

    /// <summary>
    /// Generate a prompt for the player.
    /// </summary>
    private void GeneratePrompt()
    {
        m_InputPrompt = Random.Range(0, 4);
        Debug.Log(m_InputPrompt);
        m_Prompt.sprite = m_ButtonPromptImages[m_InputPrompt];
    }

    /// <summary>
    /// Check all face buttons to see if one has been pressed by the player.
    /// </summary>
    /// <returns>If a face button has been pressed.</returns>
    private bool AnyButtonPressed()
    {
        for (int i = 0; i < 4; ++i)
        {
            if (XCI.GetButtonDown((XboxButton)i, m_CurrentPlayer))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Check which button the player has pressed.
    /// </summary>
    /// <returns>The button the player has pressed.</returns>
    private XboxButton GetFaceButtonPress()
    {
        // Check all the face buttons of the controller.
        // A button.
        if (XCI.GetButtonDown(XboxButton.A, m_CurrentPlayer))
            return XboxButton.A;
        // B button.
        else if (XCI.GetButtonDown(XboxButton.B, m_CurrentPlayer))
            return XboxButton.B;
        // X button.
        else if (XCI.GetButtonDown(XboxButton.X, m_CurrentPlayer))
            return XboxButton.X;
        // Y button.
        else if (XCI.GetButtonDown(XboxButton.Y, m_CurrentPlayer))
            return XboxButton.Y;

        // Return a random button, the player hasn't pressed a face button.
        else
            return XboxButton.Start;
    }
}