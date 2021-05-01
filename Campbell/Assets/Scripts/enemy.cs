using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private PlayerMov player;
    private int life=100;

    private void Start()
    {
        player = FindObjectOfType<PlayerMov>();
    }

    private void FixedUpdate()
    {
        follow();
        die();
    }
    void follow()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.transform.position.x,0,0),0.01f);
    }

    void die()
    {
        if (life <= 0){
            Destroy(this.gameObject);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            life -= 20;
        }
    }

}
