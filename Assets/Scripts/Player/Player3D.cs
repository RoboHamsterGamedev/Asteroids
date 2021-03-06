using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : Player
{
    Rigidbody rb3D;
    private void OnEnable()
    {
        rb3D = GetComponentInChildren<Rigidbody>();
        player = this.transform;
        CalculateOBjSize();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.Rotate(0, 0, -rotSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.Rotate(0, 0, rotSpeed);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }
        KeepPlayerInScreen();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnCollision(other);
    }

    protected override void MoveForward()
    {
        base.MoveForward();
        rb3D.AddForce(transform.up * force * speed);
    }
    protected override void CalculateOBjSize()
    {
        base.CalculateOBjSize();
        Mesh mesh = player.GetComponentInChildren<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        objectHeight = bounds.size.y * this.transform.localScale.y;
        objectWidth = bounds.size.x * this.transform.localScale.x;
    }
}
