using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonusDash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisableBonusDash(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Movement>().hasDashed = false;

            gameObject.SetActive(false);
            Destroy(gameObject);
            StartCoroutine(DisableBonusDash(5f));
        }
    }


    
}
