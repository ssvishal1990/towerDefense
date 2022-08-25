using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] List<GameObject> enemyGameObjectPrefabs;

    private void Start()
    {
        if (FindObjectOfType<EnemyMover>() != null)
        {
            target = FindObjectOfType<Enemy>().transform;
        }
    }

    private void Update()
    {
        FindClosestTartget();
        AimWeapon();
    }

    private void FindClosestTartget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float maxDistance = Mathf.Infinity;


        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestEnemy = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestEnemy;
    }

    private void AimWeapon()
    {
        if (target == null)
        {
            return;
        }
        weapon.LookAt(target);
    }
}
