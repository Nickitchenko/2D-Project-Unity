using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFlying : MonoBehaviour
{
    public GameObject player;

    //щвидкість
    public float speed;
    public float hp;
    public float hpmax;
    public Image healthImage;
    //кордони за які ми не вилітаємо

    public float[] limits;

    private Vector3 currentpoint;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;

    private Vector3 randomPoint(Vector3 point)
    {
        return new Vector3(Random.Range(limits[0], limits[1]), Random.Range(limits[2], limits[3]), 0); //0,1 -x; 0,2 - y;
    }

    private void Start()
    {
        hp = hpmax;
        currentpoint = randomPoint(currentpoint);
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        healthImage.fillAmount = hp / hpmax;
        if (transform.position.y < -2)
        {
            player.GetComponent<Player>().kills_enemy++;
            Destroy(gameObject);
        }
        else if (hp <= 0) 
        { 
            player.GetComponent<Player>().kills_enemy++; Destroy(gameObject);
        }
        rb2d.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        //політ до цієї точки
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, currentpoint, speed);

        if (currentpoint.x < transform.localPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        //щукаємо нову
        if (transform.localPosition == currentpoint)
        {
            currentpoint = randomPoint(currentpoint);
        }
    }
}
