using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isRight;
    public float speed;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(isRight)
        {
            rb2d.AddForce(transform.right*speed, ForceMode2D.Impulse);
            spriteRenderer.flipX = false;
        }
        else
        {
            rb2d.AddForce(-transform.right * speed, ForceMode2D.Impulse);
            spriteRenderer.flipX = true;
        }
        Destroy(gameObject,5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.isTrigger)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
