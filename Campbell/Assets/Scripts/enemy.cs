using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public bool died = false;
    private PlayerMov player;
    private int life=100;


    private void Start()
    {
        player = FindObjectOfType<PlayerMov>();
        GetComponent<Dialogue>().cantalk = false;
    }

    private void FixedUpdate()
    {
        if (!died)
        {
            follow();
        }
        die();
    }
    void follow()
    {
        var distance = player.transform.position - this.transform.position;
        
        if (Mathf.Abs(distance.x) <16)
             transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.transform.position.x, 0, 0), 0.05f);

    }

    void die()
    {
        if (life <= 0){

            died = true;
 
            transform.rotation = new Quaternion(90, 0, 0,0);
            gameObject.transform.GetChild(0).rotation = Quaternion.identity;
            gameObject.transform.GetChild(0).transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 4.67f, this.transform.position.z);

            GetComponent<Dialogue>().cantalk = true;
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
