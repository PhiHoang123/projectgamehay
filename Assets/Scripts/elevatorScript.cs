﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorScript : MonoBehaviour
{
    public float resetTime;

    Animator elevAnim;
    AudioSource elevAS;

    float downTime;
    bool elevIsUp = false;




    // Start is called before the first frame update
    void Start()
    {
        elevAnim = GetComponent<Animator>();
        elevAS = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if(downTime <= Time.time && elevIsUp)
        {
            elevAnim.SetTrigger("ElevatorTrigger");
            elevIsUp = false;
            elevAS.Play();
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            elevAnim.SetTrigger("ElevatorTrigger");
            downTime = Time.time + resetTime;
            elevIsUp = true;
            elevAS.Play();
        }
    }
}
