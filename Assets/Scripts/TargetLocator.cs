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
        target = FindObjectOfType<EnemyMover>().transform;
        //if (target.gameObject.GetComponent<WayPoint>() != null)
        //{
        //   targetGameObject = GetComponent<GameObject>();
        //}
    }

    private void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
