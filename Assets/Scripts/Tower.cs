using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildDelay = 1f;

    private void Start()
    {
        StartCoroutine(build());
    }

    public bool createTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null)
        {
            Debug.Log(" Bank not found ?");
            return false;
        }

        if (bank.CurrentBalance > cost)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdrawl(cost);
            return true;
        }
        return false;
    }

    IEnumerator build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            Debug.Log("Disabling  " + child.gameObject.name);
            foreach (Transform grandChild in child)
            {
                Debug.Log("Disabling  " + grandChild.gameObject.name);
                grandChild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            Debug.Log("Enabling  " + child.gameObject.name);
            foreach (Transform grandChild in child)
            {
                Debug.Log("Enabling  " + grandChild.gameObject.name);
                grandChild.gameObject.SetActive(true );
            }
        }
    }
}
