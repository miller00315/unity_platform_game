using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFrogController : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private Animator animator;

    public float speed;

    public Transform rightCol;

    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    public int score;

    private bool playerDestroyed = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;

            if (height > 0 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                speed = 0;

                animator.SetTrigger("NinjaFrogHit");

                BoxCollider2D boxCollider2D = gameObject.GetComponent<BoxCollider2D>();

                CircleCollider2D circleCollider2D = gameObject.GetComponent<CircleCollider2D>();

                boxCollider2D.enabled = false;

                circleCollider2D.enabled = false;

                rigidBody.bodyType = RigidbodyType2D.Kinematic;

                GameController.instance.UpdateScore(score);

                Destroy(gameObject, 0.33f);
            }
            else
            {
                playerDestroyed = true;

                GameController.instance.ShowGameOver();

                Destroy(collision.gameObject);
            }
        }
    }
}
