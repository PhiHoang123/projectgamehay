using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] weapons;
    bool[] weaponAvailable;
    public Image weaponImage;

    int currentWeapon;

    Animator weaponImageAnim;

    // Start is called before the first frame update
    void Start()
    {
        weaponImageAnim = weaponImage.GetComponent<Animator>();
        weaponAvailable = new bool[weapons.Length];
        for (int i = 0; i < weapons.Length; i++) weaponAvailable[i] = false;
        currentWeapon = 0;
        //turn on this gonna be use weapon in element 0 and disable secondweapon
        weaponAvailable[currentWeapon] = true;
        //turn on this and turn off weaponAvailable gonna switch and use secondweaapon
        //for (int i = 0; i < weapons.Length; i++) weaponAvailable[i] = true;

        deactivateWeapons();

        setWeaponActive(currentWeapon);

    }

    // Update is called once per frame
    void Update()
    {
        //toggle weapon
        if (Input.GetKeyDown(KeyCode.E)){
            int i;
            for(i = currentWeapon + 1; i<weapons.Length; i++)
            {
                if(weaponAvailable[i] == true)
                {
                    currentWeapon = i;
                    setWeaponActive(currentWeapon);
                    return;
                }
            }
            for (i = 0; i < currentWeapon; i++)
            {
                if (weaponAvailable[i] == true)
                {
                    currentWeapon = i;
                    setWeaponActive(currentWeapon);
                    return;
                }
            }
        }
    }

    public void setWeaponActive (int whichWeapon)
    {
        if (!weaponAvailable[whichWeapon]) return;
        deactivateWeapons();
        weapons[whichWeapon].SetActive(true);
        weapons[whichWeapon].GetComponentInChildren<FireBullet>().initializeWeapon();
        weaponImageAnim.SetTrigger("weaponSwitchImage");

    }

    void deactivateWeapons()
    {
        for (int i = 0; i < weapons.Length; i++) weapons[i].SetActive(false);
    }
    public void activateWeapon(int whichWeapon)
    {
        weaponAvailable[whichWeapon] = true;
    }
}
