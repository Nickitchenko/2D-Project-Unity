using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if (player.GetComponent<Player>().kills_enemy == player.GetComponent<Player>().AllCountEnemy && player.GetComponent<Player>().coins_count == player.GetComponent<Player>().Allcount_coins)
            {
                if(SceneManager.GetActiveScene().buildIndex==2)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
}
