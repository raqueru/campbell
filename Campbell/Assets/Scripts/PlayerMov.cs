using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private float x;
    public float JumpForce;
    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }

    private void Walk()
    {
        x = Input.GetAxis("Horizontal");
        Vector3 movement= new Vector3(x, 0, 0).normalized;
        transform.position += movement * Time.deltaTime * MoveSpeed;
    }
    private void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

    }
}
