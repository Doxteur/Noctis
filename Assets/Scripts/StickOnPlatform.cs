using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnPlatform : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            Debug.Log(collision.GetComponent<Movement>().wallGrab);

            // if player is grabing 
            if (collision.GetComponent<Movement>().wallGrab)
            {
                collision.transform.SetParent(transform);
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            Debug.Log(collision);
            Debug.Log(collision.GetComponent<Movement>().wallGrab);

            // if player is grabing 
            if (collision.GetComponent<Movement>().wallGrab)
            {
                collision.transform.SetParent(transform);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger entered");
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            collision.transform.SetParent(null);
        }
    }

}
