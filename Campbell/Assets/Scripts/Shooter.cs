using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bullet bullet;
    public Transform ponta;
    public AudioSource bulletsfx;
    private void FixedUpdate()
    {
        Spin();
        shoot();
    }

    void Spin()
    {  //Get the Screen positions of the object
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector3 mouseOnScreen = (Vector3)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
    }

    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            bullet pewpew = Instantiate(bullet, new Vector3(ponta.transform.position.x, ponta.transform.position.y + 0.80f), ponta.transform.rotation);
            pewpew.move((ponta.transform.position-transform.position).normalized);
            bulletsfx.Play();


        }
    }
}

             
 
