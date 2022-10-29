using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : MonoBehaviour
{
    //��������
    public float speed;
    //������� �� �� �� �� �������
    
    public float[] limits;

    private Vector3 currentpoint;

    private SpriteRenderer spriteRenderer;

    private Vector3 randomPoint(Vector3 point)
    {
        return new Vector3(Random.Range(limits[0], limits[1]), Random.Range(limits[2], limits[3]), 0); //0,1 -x; 0,2 - y;
    }

    private void Start()
    {
        currentpoint = randomPoint(currentpoint);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //���� �� ���� �����
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, currentpoint, speed);

        if (currentpoint.x < transform.localPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        //������ ����
        if (transform.localPosition == currentpoint)
        {
            currentpoint = randomPoint(currentpoint);
        }
    }
}
