using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    public float damageRate;
    public float pushBackForceX;
    public float pushBackForceY;


    float nextDamage;

    bool playerInRange = false;

    GameObject thePlayer;
    playerHealth ThePlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        nextDamage = Time.time;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        ThePlayerHealth = thePlayer.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange) Attack();
    }

    //Nhận diện player khi bước vào vùng trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = false;
        }
    }


    private void Attack()
    {
        if(nextDamage<= Time.time)
        {
            ThePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(thePlayer.transform);
        }
    }
    private void pushBack(Transform pushedObject)
    {
        Vector3 pushDirectionX = new Vector3((pushedObject.position.x - transform.position.x),0, 0).normalized;
        pushDirectionX *= pushBackForceX;

        Rigidbody pushRBx = pushedObject.GetComponent<Rigidbody>();
        pushRBx.velocity = Vector3.zero;
        pushRBx.AddForce(pushDirectionX, ForceMode.Impulse);

        Vector3 pushDirectionY = new Vector3(0, (pushedObject.position.y - transform.position.y) , 0).normalized;
        pushDirectionY *= pushBackForceY;

        Rigidbody pushRBy = pushedObject.GetComponent<Rigidbody>();
        pushRBy.velocity = Vector3.zero;
        pushRBy.AddForce(pushDirectionY, ForceMode.Impulse);
    }

}
