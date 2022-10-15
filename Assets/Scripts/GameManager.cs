using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int spwanTime = 3;
    private int remSpawnTime;
    public void EndGame() {
        Debug.Log("Game Ended");
    }

    private void Start()
    {
        remSpawnTime = spwanTime;
    }

    private void FixedUpdate()
    {
        //Debug.Log(remSpawnTime);
        remSpawnTime--;
        if (remSpawnTime <= 0) {
            remSpawnTime = spwanTime;
            ObjectPooler.Instance.spawnFromPool("Enemy",new Vector2(Random.Range(-8, 8), Random.Range(-4.5f, 4.5f)));
        }
    }
}
