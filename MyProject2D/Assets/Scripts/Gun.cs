using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().isgun = true;
            Destroy(gameObject);
        }
    }
}
