using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool canPlace;
    [SerializeField] Tower towerPrefab;
    public bool CanPlace { get { return canPlace; } }
    
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canPlace)
            {
                bool isPlaced = towerPrefab.createTower(towerPrefab, transform.position);
                canPlace = !isPlaced;
            }
            
        }
    }
}
