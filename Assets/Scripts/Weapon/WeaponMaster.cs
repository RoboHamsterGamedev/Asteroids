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
    bool isGameOver =false;
    private void Start()
    {
        GetAllWeapons();
        activeWeapon = weapons[activeWeaponIndex];
        GameMaster.onVisualChange += ChangeVisual;
        GameMaster.onGameOver += GameOver;
    }

    private void ChangeVisual()
    {
        GetAllWeapons();
        activeWeapon = weapons[activeWeaponIndex];
    }

    private void GameOver(int score)
    {
        isGameOver = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOver)
        {
            activeWeapon.Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !isGameOver)
        {
            ChangeWeapon();
        }
    }

    void GetAllWeapons()
    {
        if (weapons!=null) { 
            Array.Clear(weapons, 0, weapons.Length); 
        }
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
