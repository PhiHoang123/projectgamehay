using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHealth playerDeath = other.gameObject.GetComponent<playerHealth>();
            playerDeath.makeDead();

        }
        else Destroy(gameObject);
    }
}
