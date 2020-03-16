using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infecter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = gameObject.transform.position;
            gameObject.transform.position = new Vector3(pos.x -= 1.0f, pos.y, pos.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 pos = gameObject.transform.position;
            gameObject.transform.position = new Vector3(pos.x += 1.0f, pos.y, pos.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().SetInfected(true);
        }
    }
}
