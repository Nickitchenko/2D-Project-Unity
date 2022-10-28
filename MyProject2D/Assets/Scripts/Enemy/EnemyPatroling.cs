using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroling : MonoBehaviour
{
    public Vector3 leftpoint;
    public Vector3 centrepoint;
    public Vector3 rightpoint;

    public float speed;

    public int currentpoint;

    public SpriteRenderer spriteRenderer;

    private void FixedUpdate()
    {
        if(currentpoint==0)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftpoint, speed);
            if(transform.position==leftpoint)
            {
                currentpoint = 1;
                spriteRenderer.flipX = false;
            }
        }
        else if(currentpoint==1)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightpoint, speed);
            if (transform.position == rightpoint)
            {
                currentpoint = 2;
                spriteRenderer.flipX = true;
            }
        }
        else if(currentpoint==2)
        {
            transform.position = Vector3.MoveTowards(transform.position, centrepoint, speed);
            if (transform.position == centrepoint)
            {
                currentpoint = 0;
            }
        }
    }
}
