using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }

    void Interact()
    {
        Debug.Log("Heart Interacted");

        // get player and increase HeartCollected
        Movement player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        player.HeartCollected++;
        Debug.Log("HeartCollected: " + player.HeartCollected);

        Destroy(gameObject);
    }
}
