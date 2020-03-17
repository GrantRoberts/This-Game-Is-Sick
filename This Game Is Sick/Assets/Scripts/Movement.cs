using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool m_Infected;
    public float m_Speed;
    public XboxCtrlrInput.XboxController m_PlayerNumber = (XboxCtrlrInput.XboxController)1;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 motion;

        if(XboxCtrlrInput.XCI.IsPluggedIn((int)m_PlayerNumber))
        {
            motion = new Vector3(XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.LeftStickX, m_PlayerNumber), 0, XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.LeftStickY,m_PlayerNumber));
        }
        else
        {
         motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        }

        


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
