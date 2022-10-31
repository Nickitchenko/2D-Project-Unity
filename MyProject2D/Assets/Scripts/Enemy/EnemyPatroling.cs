using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatroling : MonoBehaviour
{
    public Vector3 leftpoint;
    public Vector3 centrepoint;
    public Vector3 rightpoint;

    public float speed;

    public float hp;
    public float hpmax;
    public Image healthImage;

    public int currentpoint;

    public GameObject player;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        hp = hpmax;
    }

    private void Update()
    {
        healthImage.fillAmount = hp / hpmax;
        if(transform.position.y<-2)
        {
            player.GetComponent<Player>().kills_enemy++;
            Destroy(gameObject);
        }
        else if (hp <= 0)
        {
            player.GetComponent<Player>().kills_enemy++;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(currentpoint==0)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, leftpoint, speed);
            if(transform.localPosition==leftpoint)
            {
                currentpoint = 1;
                spriteRenderer.flipX = false;
            }
        }
        else if(currentpoint==1)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, rightpoint, speed);
            if (transform.localPosition == rightpoint)
            {
                currentpoint = 2;
                spriteRenderer.flipX = true;
            }
        }
        else if(currentpoint==2)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, centrepoint, speed);
            if (transform.localPosition == centrepoint)
            {
                currentpoint = 0;
            }
        }
    }
}
