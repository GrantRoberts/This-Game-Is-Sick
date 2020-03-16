using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infecter : MonoBehaviour
{
    /// <summary>
    /// The force used to push the infecter away from players.
    /// </summary>
    public float m_PushForce = 0;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        // Set the player to infected and push them away.
        if (other.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().SetInfected(true);
            other.GetComponent<Rigidbody>().AddForce(transform.forward * m_PushForce);
            GetComponent<Rigidbody>().AddForce(transform.forward * m_PushForce);
        }
    }
}