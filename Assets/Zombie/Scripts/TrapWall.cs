using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWall : MonoBehaviour
{

    AudioSource wallAS;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        wallAS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            anim.SetTrigger("trapWallActivate");
            wallAS.Play();
            Destroy(gameObject, 1f);
        }
    }
}
