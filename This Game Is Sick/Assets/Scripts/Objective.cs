using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private bool m_PlayerInRadius = false;

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerInRadius)
        {
            if (Input.GetKey(KeyCode.Space))
                Debug.Log("Yes");
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
