using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJumping;

    private Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            Rigidbody2D.AddForce(new Vector3(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

   private void OnCollisionEnter2D(Collision2D collision) 
   {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
   }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
