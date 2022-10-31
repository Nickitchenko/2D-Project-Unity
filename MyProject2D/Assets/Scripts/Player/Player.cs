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
    public Text textdeath;
    public int Allcount_coins;
    public int AllCountEnemy;

    //portal
    public GameObject portal;

    //hp
    public float hp;
    public float hpmax;
    
    public int kills_enemy=0;

    public Image healthImage;

    public bool isCanTakeDamage = true;

    //jump
    private bool isGrounded;
    private bool doubleisGrounded;

    private Vector2 position;
    //bullet
    public GameObject bulletPtrefab;

    public Transform Leftpoint;
    public Transform Rightpoint;

    public bool isgun=false;

    private void Start()
    {
        Allcount_coins = GameObject.FindGameObjectsWithTag("Coin").Length;
        AllCountEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

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
                if (!isgun) GetComponent<Animator>().Play("idle"); //isgun or not = idle
                else GetComponent<Animator>().Play("idle_gun");
                GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse); //doublejump
                GetComponent<Animator>().SetBool("isGrounded", isGrounded);
                doubleisGrounded = false;
            }
        }
        //animation
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) //moving animation
        {
            if (isGrounded == true)
            {
                if (!isgun) GetComponent<Animator>().Play("run");
                else GetComponent<Animator>().Play("run_gun");
            }
        }
        else
        {
            if (isGrounded == true)
            { if (!isgun) GetComponent<Animator>().Play("idle");
                else GetComponent<Animator>().Play("idle_gun");
            }
        }

        GetComponent<Animator>().SetBool("isGrounded", isGrounded); //from animator to script
        GetComponent<Animator>().SetBool("isGun", isgun);

        //interface
        textcoins.text = coins_count.ToString()+"/" + Allcount_coins;
        textdeath.text = kills_enemy.ToString() + "/" + AllCountEnemy;

        //recolor portal
        if(coins_count==Allcount_coins && kills_enemy==AllCountEnemy)
        {
            Color col = new Color(0.86f, 0.45f, 1);
            portal.GetComponent<SpriteRenderer>().color = col;
        }

        healthImage.fillAmount = hp / hpmax;
        
        if(hp<=0)//restart level if hp zero
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKeyDown(KeyCode.Space))//shot for gun
        {
            if (isgun)
            {
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    Instantiate(bulletPtrefab, Rightpoint.position, Quaternion.identity, null).GetComponent<Bullet>().isRight = !GetComponent<SpriteRenderer>().flipX;
                }
                else
                {
                    Instantiate(bulletPtrefab, Leftpoint.position, Quaternion.identity, null).GetComponent<Bullet>().isRight = !GetComponent<SpriteRenderer>().flipX;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
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
