using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standart_Weapon : Weapon
{
    public GameObject _bulletPrefab = null;
    [SerializeField] List<GameObject> bulletsPool = new List<GameObject>();
    [SerializeField] Transform _bulletFolder;

    public override void Shoot()
    {
        base.Shoot();
        RequestBullet();
    }
    GameObject RequestBullet()
    {
        foreach (var bullet in bulletsPool)
        {
            if (bullet.activeInHierarchy == false)
            {
                bullet.SetActive(true);
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = this.transform.rotation;
                return bullet;
            }
        }
        CreateNewBullet();
        return RequestBullet();
    }
    void CreateNewBullet()
    {
        GameObject _bullet = Instantiate(_bulletPrefab); 
        _bullet.transform.parent = _bulletFolder;
        _bullet.SetActive(false);
        bulletsPool.Add(_bullet); 
    }
}
