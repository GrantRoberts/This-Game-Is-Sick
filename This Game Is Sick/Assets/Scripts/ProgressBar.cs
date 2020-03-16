using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
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
    /// Speed the progress decreases at.
    /// </summary>
    public float m_DecreaseSpeed = 0.0f;

    private bool m_ProgressIncreased = false;

    private Slider m_Slider;

    private void Awake()
    {
        m_Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Progress > 0.0f)
        {
            if (!m_ProgressIncreased)
            {
                m_Progress -= m_DecreaseSpeed * Time.deltaTime;
                m_Slider.value = m_Progress;
            }
            else
                m_ProgressIncreased = false;
        }
    }

    public void IncreaseProgress()
    {
        if (m_Progress < 1.0f)
        {
            m_ProgressIncreased = true;
            // Increase the progress by the speed by delta time.
            m_Progress += m_ProgressSpeed * Time.deltaTime;
            // Set the bar's value.
            m_Slider.value = m_Progress;
        }
    }
}
