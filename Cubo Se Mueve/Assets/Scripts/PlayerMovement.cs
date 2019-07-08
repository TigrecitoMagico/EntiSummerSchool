using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float velocity;
    public float verticalForceMagnitude;
    Rigidbody2D rb;
    bool isGrounded;
    bool doublejump = false; 
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
	}

    // FixedUpdate por si hay bajadas de fps
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && doublejump)
        {
            rb.AddForce(Vector2.up * verticalForceMagnitude);
            
            doublejump = false; 
           
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            rb.AddForce(Vector2.up * verticalForceMagnitude);
    
     
            doublejump = true;
            isGrounded = false;



        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity += Vector2.right * velocity;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity += Vector2.left * velocity;
        }
       
       
    }
    void Update () {
        Vector2 targetVelocity; 
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.tag == "Ground")
        {
            isGrounded = true;
        } 
    }
}
