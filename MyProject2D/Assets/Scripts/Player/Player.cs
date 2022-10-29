using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //player
    public int coins_count=0;
    public float speed;
    public float jumpForce;

    //interface
    public Text textcoins;

    //hp
    public float hp;
    public float hpmax;

    public Image healthImage;

    public bool isCanTakeDamage = true;

    //jump
    private bool isGrounded;
    private bool doubleisGrounded;

    private Vector2 position;

    public GameObject bulletPtrefab;

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
    }

    private void Update()
    {
        //restart level
        if(transform.position.y < -2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //move
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
                GetComponent<Animator>().Play("idle");
                GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                GetComponent<Animator>().SetBool("isGrounded", isGrounded);
                doubleisGrounded = false;
            }
        }
        //animation
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if(isGrounded == true) GetComponent<Animator>().Play("run");
        }
        else
        {
            if(isGrounded==true) GetComponent<Animator>().Play("idle");
        }
        GetComponent<Animator>().SetBool("isGrounded", isGrounded);

        //interface
        textcoins.text = (coins_count.ToString() + " Coins");

        healthImage.fillAmount = hp / hpmax;
        
        if(hp<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPtrefab, transform.position, Quaternion.identity, null).GetComponent<Bullet>().isRight = !GetComponent<SpriteRenderer>().flipX;
        }

    }

    IEnumerator damageTimer()
    {
        yield return new WaitForSeconds(0.2f);
        isCanTakeDamage = true;
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
