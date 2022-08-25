using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] ParticleSystem BulletFiringParticleSysmtem;
    [SerializeField] List<GameObject> enemyGameObjectPrefabs;
    [SerializeField] float towerRange = 15f;
    float maxDistance = Mathf.Infinity;

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
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestEnemy = enemy.transform;
                maxDistance = targetDistance;
            }
        }        
    }

    private void AimWeapon()
    {
        if (target == null)
        {
            return;
        }
        weapon.LookAt(target);
        if (maxDistance < towerRange)
        {
            Attack(true);
        }else
        {
            Attack(false);
        }
    }

    void Attack(bool canAttack)
    {
        var particleSystemEmissionModule = BulletFiringParticleSysmtem.emission;
        particleSystemEmissionModule.enabled = canAttack;
    }
}
