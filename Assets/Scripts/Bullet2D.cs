using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2D : Bullet
{
    private void FixedUpdate()
    {
        Movement();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        OnCollision(collision);

    }
}
