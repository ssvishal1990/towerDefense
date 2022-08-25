using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    int currentHitPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Inside OnParticleCollision");
        processHit();
    }

    private void processHit()
    {
        
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            Debug.Log("Enemy GameObject Destroyed");
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
