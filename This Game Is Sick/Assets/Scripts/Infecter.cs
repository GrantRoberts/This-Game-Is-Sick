using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Infecter : MonoBehaviour
{
    /// <summary>
    /// The force used to push the infecter away from players.
    /// </summary>
    public float m_PushForce = 0;


   public GameObject m_VirusImage;
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

            //Check if the virus has won the game
            //Find all players
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            int infectedCount = 0;


            if (players != null)
            {
                //For every playera
                for (int i = 0; i < players.Length; i++)
                {
                    //Check if they are infected
                    if (players[i].GetComponent<Player>().GetInfected())
                    {
                        //If they are, add to count
                        infectedCount++;
                    }
                }
            }
            //if every player is infected
            if (infectedCount >= players.Length)
            {
                //virus wins
                m_VirusImage.SetActive(true);
            }
            otherR.AddForce(direction * m_PushForce,ForceMode.Impulse);
            //otherR.velocity += direction * m_PushForce;
            GetComponent<Rigidbody>().AddForce(direction * -m_PushForce, ForceMode.Impulse);
            //GetComponent<Rigidbody>().velocity += -direction * m_PushForce;
        }
    }
}