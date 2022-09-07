using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool canPlace;
    [SerializeField] Tower towerPrefab;
    public bool CanPlace { get { return canPlace; } }

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    private void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!canPlace)
            {
                gridManager.BlockedNode(coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.willBlockPath(coordinates))
        {
            bool isSuccessful  = towerPrefab.createTower(towerPrefab, transform.position);
            if(isSuccessful)
            {
                gridManager.BlockedNode(coordinates);
                pathfinder.NotifyReceivers();
            }
            
        }
    }
}
