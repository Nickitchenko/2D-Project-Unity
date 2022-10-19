using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool isGrounded;
    private bool doubleisGrounded;

    private Vector2 position;

    private void FixedUpdate()
    {
        //moving
        position = transform.position;        
        if(Input.GetKey(KeyCode.D))
        {
            position.x += speed;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.position = position;     
        //animation
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().Play("run");
        }
        else
        {
            GetComponent<Animator>().Play("idle");
        }
    }

    private void Update()
    {
        if(transform.position.y < -2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //restran level
        }

        if(Input.GetKeyDown(KeyCode.W)/* && isGrounded==true*/)
        {
            if (isGrounded == true)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
            else if(isGrounded==false && doubleisGrounded==true)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                doubleisGrounded = false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            isGrounded = true;
            doubleisGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
