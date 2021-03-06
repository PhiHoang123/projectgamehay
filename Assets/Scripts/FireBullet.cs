using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBullet : MonoBehaviour
{
    public float firerate = 0.15f;
    public GameObject projectile;


    public Slider playerAmmoSlider;
    public int maxRounds;
    public int startingRounds;
    int remainingRounds;

    float nextBullet;

    AudioSource gunMuzzleAS;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    //graphics infor
    public Sprite weaponSprite;
    public Image weaponImage;

    Animator myAnim;



    // Start is called before the first frame update
    void Awake()
    {
        nextBullet = 0f;
        remainingRounds = startingRounds;
        playerAmmoSlider.maxValue = maxRounds;
        playerAmmoSlider.value = remainingRounds;
        gunMuzzleAS = GetComponent<AudioSource>();
        myAnim = GetComponentInParent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        PlayerController myPlayer = transform.root.GetComponent<PlayerController>();

        if (Input.GetAxisRaw("Fire1")>0 && nextBullet<Time.time && remainingRounds>0)
        {
            nextBullet = Time.time + firerate;
            Vector3 rot;
            if (myPlayer.GetFacing() == -1f)
            {
                rot = new Vector3(0, -90, 0);
            }else rot = new Vector3 (0, 90 ,0 );

            Instantiate(projectile, transform.position, Quaternion.Euler(rot));

            playASound(shootSound);

            remainingRounds -= 1;
            playerAmmoSlider.value = remainingRounds;
            myAnim.Play("shoot",0,0);
        }
    }

    public void reload()
    {
        remainingRounds = maxRounds;
        playerAmmoSlider.value = remainingRounds;
        playASound(reloadSound);
    }

    void playASound(AudioClip playTheSound)
    {

        gunMuzzleAS.clip = playTheSound;
        gunMuzzleAS.Play(); 
    }
    public void initializeWeapon()
    {
        gunMuzzleAS.clip = reloadSound;
        gunMuzzleAS.Play();
        nextBullet = 0;
        playerAmmoSlider.maxValue = maxRounds;
        playerAmmoSlider.value = remainingRounds;
        weaponImage.sprite = weaponSprite;
    }

}
