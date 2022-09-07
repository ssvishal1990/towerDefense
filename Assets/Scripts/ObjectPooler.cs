using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField][Range(0f, 50f)] Tile startPoint;
    [SerializeField][Range(0.1f, 2f)] float spawnTimer = 1f;

    [SerializeField] int poolSize = 5;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(instantiateEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator instantiateEnemies()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(spawnTimer);
            EnableObjectInPool();
        }
    }

    private void EnableObjectInPool()
    {
        foreach(GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return;
            }
        }
    }
}
