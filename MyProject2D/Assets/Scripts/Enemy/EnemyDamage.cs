using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public float forcedamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.GetComponent<Player>().isCanTakeDamage == true)
            {
                collision.gameObject.GetComponent<Player>().hp -= damage;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * forcedamage, ForceMode2D.Impulse);
                collision.gameObject.GetComponent<Player>().isCanTakeDamage = false;
                collision.gameObject.GetComponent<Player>().StartCoroutine("damageTimer");
            }
        }
    }
}
