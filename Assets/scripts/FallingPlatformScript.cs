using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformScript : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D targetJoint2D;

    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        targetJoint2D = GetComponent<TargetJoint2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            // Call method after a delay in seconds
            Invoke("Falling", fallingTime);
        }
    }

    
    void OnTriggerEnter2D(Collider2D collider) 
    {   
        // When trigger is enable destroy if touch in layer 9
        if (collider.gameObject.layer == 9)
        {
           Destroy(gameObject); 
        }
    }

    void Falling()
    {
        targetJoint2D.enabled = false;
        boxCollider2D.isTrigger = true;
    }
}
