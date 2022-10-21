using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())  
        {
            collision.gameObject.GetComponent<Player>().coins_count++;
            Destroy(gameObject);
        }
    }
}
