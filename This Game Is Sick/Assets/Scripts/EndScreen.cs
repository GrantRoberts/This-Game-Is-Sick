using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class EndScreen : MonoBehaviour
{
	/// <summary>
	/// For delaying the timer, so a player doing the qte doens't immedietly skip the end screen.
	/// </summary>
    public float m_InputDelayTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (m_InputDelayTimer <= 0.0f)
        {
            if (AnyButtonPressed())
            {
				// Load the main menu scene.
				SceneManager.LoadScene("MainMenu");   
            }
        }
        else
        {
            m_InputDelayTimer -= Time.deltaTime;
        }
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
