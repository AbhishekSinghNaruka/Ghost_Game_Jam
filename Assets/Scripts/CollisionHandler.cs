using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            Debug.Log("destroying" + collision.gameObject.tag);
            player.health -= collision.gameObject.GetComponent<EnemyScript>().damageAmount;
            collision.gameObject.SetActive(false);
            if (player.health <= 0) {
                FindObjectOfType<GameManager>().EndGame();
            }
        }


    }
}
