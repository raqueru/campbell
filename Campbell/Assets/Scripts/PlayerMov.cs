using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private float x;
    public int life = 100;
    public float JumpForce;
    public float MoveSpeed;
    private bool grounded = false;
    public AudioSource jumpsfx;
    public GameObject end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Walk();
        Jump();
        die();
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (col.gameObject.tag == "Enemy")
        {
            life -= 10;
        }
    }
    private void Walk()
    {
        x = Input.GetAxis("Horizontal");
        Vector3 movement= new Vector3(x, 0, 0).normalized;
        transform.position += movement * Time.deltaTime * MoveSpeed;
    }
    private void Jump()
    {
        if (Input.GetKeyDown("space")&& grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            grounded = false;
            jumpsfx.Play();
        }

    }
    void die()
    {
        if (life <= 0)
        {
            Time.timeScale = 0;
            end.gameObject.SetActive(true);
        }
    }
}
