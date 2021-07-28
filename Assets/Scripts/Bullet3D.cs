using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3D : Bullet
{
    private void FixedUpdate()
    {
        Movement();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnCollision(other);
    }
}
