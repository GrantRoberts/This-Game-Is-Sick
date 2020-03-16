using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool m_Infected;
    public float m_Speed;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {




        Vector3 motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (motion.magnitude > 0.0f)
        {
            m_Rigidbody.transform.localRotation = Quaternion.LookRotation(motion, Vector3.up);
            // motion.Normalize();
            //m_Rigidbody.AddForce(motion * m_Speed * Time.deltaTime,ForceMode.VelocityChange);

            m_Rigidbody.velocity = motion * m_Speed * Time.deltaTime;
        }
        else
        {
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }


        // m_Rigidbody.AddForce(,ForceMode.VelocityChange);
    }

}
