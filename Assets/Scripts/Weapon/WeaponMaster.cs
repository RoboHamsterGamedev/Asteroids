using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMaster : MonoBehaviour
{
    GameObject weaponParent;
    Weapon[] weapons;
    int activeWeaponIndex = 0;
    Weapon activeWeapon;
    private void Start()
    {
        GetAllWeapons();
        activeWeapon = weapons[activeWeaponIndex];
        GameMaster.onVisualChange += ChangeVisual;
    }

    private void ChangeVisual()
    {
        Debug.Log("Смена оружия");
        GetAllWeapons();
        activeWeapon = weapons[activeWeaponIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activeWeapon.Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ChangeWeapon();
        }
    }

    void GetAllWeapons()
    {
        if (weapons!=null) { Array.Clear(weapons, 0, weapons.Length); }
        weaponParent = GameObject.FindGameObjectWithTag("Weapon");
        weapons = weaponParent.GetComponentsInChildren<Weapon>();
    }
    void ChangeWeapon()
    {
        if (activeWeaponIndex == weapons.Length - 1)
        {
            activeWeaponIndex = 0;
        }
        else activeWeaponIndex += 1;

        activeWeapon = weapons[activeWeaponIndex];
        UIManager.instance.ChangeWeapon(activeWeaponIndex);
    }
}
