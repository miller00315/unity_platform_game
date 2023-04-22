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

    private Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator  = GetComponent<Animator>();
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

        if(Input.GetAxis("Horizontal") > 0f)
        {

            Animator.SetBool("walk", true);

            transform.eulerAngles = new Vector3(0f, 0f, 0f);

        } else if(Input.GetAxis("Horizontal") < 0f) 
        {

            Animator.SetBool("walk", true);

            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        } else 
        {
           Animator.SetBool("walk", false); 
        }

    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
               ExecuteJump();
                doubleJumping = true;
                Animator.SetBool("jump", true);
            } else if (doubleJumping)
            {
                ExecuteJump(2f);
                doubleJumping = false; 
            }
            
        }
    }

    private void ExecuteJump(float factor = 1f)
    {
         Rigidbody2D.AddForce(new Vector3(0f, JumpForce * factor), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            Animator.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
