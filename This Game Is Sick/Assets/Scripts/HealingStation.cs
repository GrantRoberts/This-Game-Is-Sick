using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class HealingStation : MonoBehaviour
{
 
    public float m_HealPerSec = 0.3f;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //If the collision object is a player
        if (other.gameObject.tag == "Player")
        {
            //Get the player script
            Player p = other.gameObject.GetComponent<Player>();

            //If they are infected
            if(p.GetInfected())
            {
               
                    //Heal the player
                    p.SetHealth(p.GetHealth() + m_HealPerSec * Time.deltaTime);


                    if(p.GetHealth() <= 0)
                    {
                        p.SetInfected(false);
                        Debug.Log("No longer infected");
                    }
                    //log the health
                    Debug.Log(p.GetHealth());
                
            }
        }
    }
}
