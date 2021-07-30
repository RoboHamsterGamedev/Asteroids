using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : Enemy
{
    public int health = 3;
    public float speed = 1;

    private void Start()    
    {
        var spawnRotation = Random.Range(0, 359);
        this.transform.rotation = Quaternion.Euler(0, 0, spawnRotation);
        InvokeRepeating("CheckIfLeftScreen", 4, 4);
        
    }

   
    public override void Moving()
    {
        base.Moving();
        this.transform.position += this.transform.up * Time.deltaTime *speed;
    }

    public override void Damage(int amt)
    {
        base.Damage(amt);
        GameMaster.instance.AddScore(30/health);
        
        if (amt>=health) 
        {
            Death();
        }
        else
        {
            BreakIntoParticles();
            Destroy(parent.gameObject);
        }
        
    }

    private void BreakIntoParticles()
    {
        health -= 1;
        parent.transform.localScale /= 2;
        speed += 1;
        GameObject[] particles = new GameObject[3];
        for(int i=0; i<particles.Length; i++)
        {
            particles[i] = Instantiate(parent, parent.transform.parent);
            particles[i].transform.position = this.transform.position;
        }
    }

    public void ChangeAsteroid(int health)
    {
        this.health = health;
        for (int i=3; i<health; i--)
        {
            this.speed += 1;
        }
    }
}
