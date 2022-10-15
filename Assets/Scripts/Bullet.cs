using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    private Rigidbody2D bulletRb;
    void Start()
    {
        bulletRb = gameObject.GetComponent<Rigidbody2D>();
        float xVelocity = -Mathf.Sin(Mathf.Deg2Rad * bulletRb.rotation) * speed;
        float yVelocity = Mathf.Cos(Mathf.Deg2Rad * bulletRb.rotation) * speed;
        bulletRb.velocity = new Vector2(xVelocity, yVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            enemyScript.damage();
            Destroy(gameObject);
        }
    }
}
