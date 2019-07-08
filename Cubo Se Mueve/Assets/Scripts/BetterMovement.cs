using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class BetterMovement : MonoBehaviour {
    [SerializeField]
     float velocity;
    bool isTopDown = true;


    Rigidbody2D rb;
    float verticalmove;
    float horizontalmove;
    [SerializeField]
   float verticalforce = 10.0f;
    bool isGrounded;
    bool wasPressed;
    // Awake: independientemente si el programa esta en funcionamiento se inicia
    private void Awake()
    {
        isGrounded = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void moveCharacter()
    {
        if (isTopDown == false)
        {

            rb.gravityScale = 1.0f;
            horizontalmove = Input.GetAxisRaw("Horizontal") * velocity;
            Vector2 targetvelocity = new Vector2(horizontalmove, rb.velocity.y);
            Vector2 m_velocity = Vector2.zero;
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetvelocity, ref m_velocity, 0.05f);
            //smoothdamp: suavizar la velocidad, el movimiento
        }
        else
        {
            rb.gravityScale = 0.0f;
            horizontalmove = Input.GetAxisRaw("Horizontal") * velocity;
            verticalmove = Input.GetAxisRaw("Vertical") * velocity;

            Vector2 targetvelocity = new Vector2(horizontalmove, verticalmove);
            Vector2 m_velocity = Vector2.zero;
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetvelocity, ref m_velocity, 0.05f);
        }
    }

    void betterjump()
    {
        float fallMultiplier = 2.5f;
        float lowJumpMultiplier = 2.0f;

        if(Input.GetButtonDown("Jump") && wasPressed)
        {
            rb.velocity = Vector2.up * verticalforce;
           
        }
        else
        {
            wasPressed = false;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }

    }

    // Use this for initialization
    void Start () {
		
	}


    private void FixedUpdate()
    {
        //localiza todo los elementos con los que estamos colisionando a partir de una esfera de radio 1.0f
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1.0f);
        //cada interaccion desde el elemnto 0 hasta el ultimo elemento sumara 1 a la variable i
        for (int i = 0; i< collider.Length;i++)
        {
            if(collider[i].gameObject.tag == "Ground")
            {
                wasPressed = true;

            }
        }
        moveCharacter();
        if (isTopDown == false)
        {
            betterjump();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
