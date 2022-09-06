using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Adds amounts to max hit points when enemy dies")]
    [SerializeField] int difficultyRamp = 5;



    Enemy enemy;
    [SerializeField]int currentHitPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHitPoints;
        enemy = GetComponent<Enemy>();
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
            maxHitPoints += difficultyRamp;
            enemy.onDeath();
            gameObject.SetActive(false);
            currentHitPoints = maxHitPoints;
        }
    }

}
