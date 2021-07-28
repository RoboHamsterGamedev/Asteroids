using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject bullet;
    float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        bullet = this.gameObject;
       Invoke("Hide", 4f);
    }

    protected virtual void Movement()
    {
        this.transform.position += this.transform.up * Time.deltaTime * speed;
    }
    protected void OnCollision(Component collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Damage(1);
            Hide();
        }
    }
    private void Hide()
    {
        bullet.SetActive(false);
    }

}
