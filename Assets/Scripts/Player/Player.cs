using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    protected Transform player;
    protected float objectWidth;
    protected float objectHeight;
    protected Animator animator;

    protected bool isMovingForward = false;

    float screenWidth;
    float screenHeight;
    protected float force = 1;
    protected float speed = 3;
    protected float rotSpeed = 3;

    private void Awake()
    {
        if (instance == null) { instance = this.transform.GetComponent<Player>(); }
    }
    private void Start()
    {
       screenWidth = GameMaster.instance.screenWidth;
       screenHeight = GameMaster.instance.screenHeight;
    }
    protected void KeepPlayerInScreen() 
    {
        Vector3 viewPos = player.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenWidth * -1 + objectWidth, screenWidth - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenHeight* -1 + objectHeight/2, screenHeight - objectHeight/2); 
        player.position = viewPos;
    }

    protected void OnCollision(Component collision)
    {
        if (collision.tag == "Enemy")
        {
            GameMaster.instance.GameOver();
            this.enabled = false;
            if (animator!=null)
            { this.animator.SetTrigger("Death"); }
        }
    }
  
    protected virtual void MoveForward ()
    {
       
    }

    protected virtual void CalculateOBjSize() { }
}
