using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool canPlace;
    [SerializeField] GameObject towerPrefab;
    public bool CanPlace { get { return canPlace; } }
    
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(gameObject.name);
            if (canPlace)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                canPlace = !canPlace;
            }
            
        }
    }
}
