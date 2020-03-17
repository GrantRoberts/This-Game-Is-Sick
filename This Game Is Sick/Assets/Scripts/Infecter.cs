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

            Rigidbody otherR = other.GetComponent<Rigidbody>();

            Vector3 direction = otherR.transform.position - transform.position;
            direction.Normalize();

            collision.gameObject.GetComponent<Player>().SetInfected(true);


            otherR.AddForce(direction * m_PushForce,ForceMode.Impulse);
            //otherR.velocity += direction * m_PushForce;
            GetComponent<Rigidbody>().AddForce(-direction * m_PushForce, ForceMode.Impulse);
            //GetComponent<Rigidbody>().velocity += -direction * m_PushForce;
        }
    }
}