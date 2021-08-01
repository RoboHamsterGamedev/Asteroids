using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAsteroid : SwapVisualObject
{
    private void OnEnable()
    {
        Prepare();
    }
    private void OnDestroy()
    {
        OnDeath();
    }
    protected override void SwapBodies(GameObject activeBody, GameObject futureBody)
    {
       base.SwapBodies(activeBody, futureBody);
        Asteroids activeEnemy = activeBody.GetComponent<Asteroids>();
        Asteroids futureEnemy = futureBody.GetComponent<Asteroids>();
        futureEnemy.ChangeAsteroid(activeEnemy.health);
    }
    
}
