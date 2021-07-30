using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Enemy
{
    Transform target;
    float speed = 1f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("CheckIfLeftScreen", 4, 4);
    }
    
    public override void Moving()
    {
        base.Moving();
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    public override void Damage(int amt)
    {
        base.Damage(amt);
        GameMaster.instance.AddScore(20);
        Death();
        
    }
}
