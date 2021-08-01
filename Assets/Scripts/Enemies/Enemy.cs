using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected GameObject parent;
    float safeZone = 2;
    protected Animator animator;

    private void Awake()
    {
        parent = transform.parent.gameObject;
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public virtual void Moving() {}

    public virtual void Damage(int amt){
    }
    public virtual void Death()
    {
        this.gameObject.tag = "DeadEnemy";
        if (TryGetComponent(out Animator animator))
            animator.SetTrigger("EnemyDeath"); 
        Destroy(parent.gameObject, 1);
    }

    public virtual void Shoot() {}

   protected void CheckIfLeftScreen()
    {
        var pos = this.transform.position;
        var screenWidth = GameMaster.instance.screenWidth;
        var screenHeight = GameMaster.instance.screenHeight;
        bool isOffScreen;

        if (pos.x > screenWidth + safeZone || pos.x < (screenWidth * -1) - safeZone)
        {
            isOffScreen =true;
        }
         else if (pos.y > screenHeight + safeZone || pos.y < (screenHeight * -1) - safeZone)
        {
            isOffScreen =true;
        }
        else isOffScreen =false;
        if (isOffScreen == true)
        {
            Destroy(parent);
        }
    }
}
