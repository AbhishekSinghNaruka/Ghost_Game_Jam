using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageAmount = 1;
    public int[]health =  new int[3];
    public List<Sprite> ghostSprites;
    private Rigidbody2D enemyRb;
    [SerializeField] private int maxSpwanXForce=5;
    [SerializeField] private int maxSpwanYForce=5;
    private int currInstanceHealth;
    void Start()
    {
        enemyRb= gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        int spwanGhostId = Random.Range(0, 3);
        //Debug.Log(spwanGhostId);
        gameObject.GetComponent<SpriteRenderer>().sprite = ghostSprites[spwanGhostId];
        currInstanceHealth = health[spwanGhostId];
        enemyRb = gameObject.GetComponent<Rigidbody2D>();
        enemyRb.AddForce(new Vector2(Random.Range(-maxSpwanXForce, maxSpwanXForce), Random.Range(-maxSpwanYForce, maxSpwanYForce)));
    }

    public void damage() {
        currInstanceHealth--;
        if (currInstanceHealth <= 0) {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
