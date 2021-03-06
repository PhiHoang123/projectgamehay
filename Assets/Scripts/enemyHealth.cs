using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class enemyHealth : MonoBehaviour
{

    public float enemyMaxHealth;
    public float damageModifier;
    public GameObject damageParticles;
    public GameObject drop;
    public bool drops;
    public AudioClip deathSound;
    public bool canBurn;
    public float burnDamage;
    public float burnTime;
    public GameObject burnEffects;

    bool onFire;
    float nextBurn;
    float burnInterval = 1f;
    float endBurn;

    float currentHealth;

    public Slider enemyHealthSlider;
    AudioSource enemyAS;            


    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthSlider.maxValue = enemyMaxHealth;
        enemyHealthSlider.value = currentHealth;
        enemyAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onFire && Time.time > nextBurn)
        {
            addDamage(burnDamage);
            nextBurn += burnInterval;
        }
        if(onFire && Time.time > endBurn)
        {
            onFire = false;
            burnEffects.SetActive(false);
        }
    }


    public void addDamage(float damage)
    {
        //hiện slider khi dính đạn
        enemyHealthSlider.gameObject.SetActive(true);
        damage = damage * damageModifier;
        if (damage <= 10f) return;
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        enemyAS.Play();
        if (currentHealth <= 0) makeDead();
    }

    public void damageFX(Vector3 point, Vector3 rotation)
    {
        Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }

    public void addFire()
    {
        if (!canBurn) return;
        onFire = true;
        burnEffects.SetActive(true);
        endBurn = Time.time + burnTime;
        nextBurn = Time.time + burnInterval;
    }

    void makeDead()
    {
        //off movement and make RagDoll
        EnemyController aZombie = GetComponentInChildren<EnemyController>();
        if(aZombie !=null)
        {
            aZombie.ragDollDeath();
        }


        AudioSource.PlayClipAtPoint(deathSound, transform.position, 10f);


        Destroy(gameObject.transform.root.gameObject);
        if (drops) Instantiate(drop, transform.position, Quaternion.identity);
    }

}
