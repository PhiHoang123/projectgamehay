using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float damage;
    public float knockBack;
    public float knockBackRadius;
    public float meleeRate;

    float nextMelee;

    int shootableMask;

    Animator myAnim;
    PlayerController myPC; 

    // Start is called before the first frame update
    void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        myAnim = transform.GetComponentInParent<Animator>();
        myPC = transform.root.GetComponent<PlayerController>();
        nextMelee = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float melee = Input.GetAxis("Fire2");
        if(melee > 0 && nextMelee < Time.time && !(myPC.getRunning()))
        {
            myAnim.SetTrigger("gunMelee");
            nextMelee = Time.time + meleeRate;

            Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);

            int i = 0;
            while(i< attacked.Length)
            {
                if(attacked[i].tag == "Enemy")
                {
                    enemyHealth doDamage = attacked[i].GetComponent<enemyHealth>();
                    doDamage.addDamage(damage);
                    doDamage.damageFX(transform.position, transform.localEulerAngles);
                }
                i++; 
            }
        }
    }
}
