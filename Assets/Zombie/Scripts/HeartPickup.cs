using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public float healthAmount;
    public AudioClip healthSound;

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
        if(other.tag == "Player") {
            other.GetComponent<playerHealth>().addHealth(healthAmount);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(healthSound, transform.position, 1f);
        }
    }
}
