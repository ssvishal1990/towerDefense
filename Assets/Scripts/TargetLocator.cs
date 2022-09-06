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



    //Used to Debug 
    [SerializeField] List<float> distanceToEnemy;


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
            
            Debug.DrawLine(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestEnemy = enemy.transform;
                maxDistance = targetDistance;
            }

            target = closestEnemy;
        }        
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        weapon.LookAt(target);
        if (targetDistance < towerRange)
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
