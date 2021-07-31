using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : Player
{
    Rigidbody2D rb2D;
    private void OnEnable()
    {
        rb2D = GetComponentInChildren<Rigidbody2D>();
        player = this.transform;
        CalculateOBjSize();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.rotation *= Quaternion.Euler(0, 0, -rotSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.rotation *= Quaternion.Euler(0, 0, rotSpeed);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {   isMovingForward = false;
            animator.SetBool("MoveForward", isMovingForward);
        }
        KeepPlayerInScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision(collision);
    }
    protected override void MoveForward()
    {
        base.MoveForward();
        rb2D.AddForce(transform.up * force * speed);
        if (!isMovingForward)
        {
            isMovingForward = true;
            animator.SetBool("MoveForward", isMovingForward);
        }
    }
    protected override void CalculateOBjSize()
    {
        base.CalculateOBjSize();
        objectHeight = this.transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
        objectWidth = this.transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
    }
}
