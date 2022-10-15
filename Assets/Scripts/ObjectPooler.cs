using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    [System.Serializable]
    public class Pool {
        public string tag;
        public int size;
        public GameObject prefab;
    }

    #region Singelton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> poolList;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in poolList) {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, queue);
        }
    }

    public GameObject spawnFromPool(string tag, Vector2 pos) {
        if (!poolDictionary.ContainsKey(tag) || poolDictionary[tag].Count ==0) {
            Debug.LogError("Tag not found or empty queue");
            return null;
        }
        GameObject objToSpawn = poolDictionary[tag].Dequeue();
        objToSpawn.transform.position =pos;
        objToSpawn.SetActive(true);
        poolDictionary[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }

}
