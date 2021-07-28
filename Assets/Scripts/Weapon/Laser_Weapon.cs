using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Weapon : Weapon
{
    private Transform player;
    Vector3 playerPos;
    [SerializeField] private Transform laserPrefab;
    public LayerMask whattohit;
    private int laserdistance = 50;
    private float laserFullPower = 60;
    private float laserCurrentPower;
    private float oneLaserCost = 10;
    private Vector3 direction;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        laserCurrentPower = laserFullPower-1;
        
    }
    private void FixedUpdate()
    {
        if (laserCurrentPower != laserFullPower)
        { 
            laserCurrentPower = laserCurrentPower + Time.deltaTime*1;
            UIManager.instance.LaserPowerUI(laserCurrentPower);
        }
    }
    public override void Shoot()
    {
       
        base.Shoot();
        if (laserCurrentPower >= oneLaserCost)
        {
            playerPos = player.position;
            direction = player.up * laserdistance;
            Debug.DrawLine(playerPos, direction, Color.red);

            CheckCollisions();
            Effect();
            MinusLaserPower();
        }
        else
        {
            //denied sound
            //ui blink
        }
       
        void CheckCollisions()
        {

            CheckCollisions2D();
            CheckCollisions3D();

            void CheckCollisions2D()
            {
                RaycastHit2D[] hits;
                hits = Physics2D.RaycastAll(playerPos, direction, 100.0F);

                for (int i = 0; i < hits.Length; i++)
                {
                    Transform hit = hits[i].transform;
                    DestroyEnemy(hit);
                }
            }
            void CheckCollisions3D()
            {
                RaycastHit[] hits;
                hits = Physics.RaycastAll(playerPos, direction, 100.0F);

                for (int i = 0; i < hits.Length; i++)
                {
                    Transform hit = hits[i].transform;
                    DestroyEnemy(hit);
                }
            }

            void DestroyEnemy(Transform hit)
            {
                Enemy enemy = hit.GetComponent<Enemy>();

                if (enemy)
                {
                    enemy.Damage(3);
                }
            }
        }
        void Effect()
        {
            var playerRot = player.transform.rotation;
            Transform trail = Instantiate(laserPrefab, playerPos, playerRot) as Transform;
            LineRenderer lr = trail.GetComponent<LineRenderer>();
            if (lr != null)
            {
                lr.SetPosition(0, playerPos);
                lr.SetPosition(1, direction);
            }
            Destroy(trail.gameObject, 0.04f);
        }
        void MinusLaserPower()
        {
            if (laserCurrentPower>= oneLaserCost + 1)
            { 
                laserCurrentPower -= oneLaserCost; 
            }
            else laserCurrentPower = 1;
            UIManager.instance.LaserPowerUI(laserCurrentPower);
        }
    }

    

}
    

