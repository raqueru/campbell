using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float shootingspeed;
    public void move(  Vector3 mov)
    {
        
        GetComponent<Rigidbody2D>().AddForce(mov * shootingspeed, ForceMode2D.Impulse);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag!="Player")
        Destroy(this.gameObject);
    }

}
