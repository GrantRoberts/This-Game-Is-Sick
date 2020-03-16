using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infecter : MonoBehaviour
{
    public float m_PushForce;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().SetInfected(true);
            other.GetComponent<Rigidbody>().AddForce(transform.forward * m_PushForce);
            GetComponent<Rigidbody>().AddForce(transform.forward * m_PushForce);
        }
    }
}
