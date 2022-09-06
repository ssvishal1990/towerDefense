using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager GridManager;
    Dictionary<Vector2Int, Node> grid;

    private void Awake()
    {
        GridManager = FindObjectOfType<GridManager>();
        if (GridManager != null)
        {
            grid = GridManager.Grid;
        }
    }

    private void Start()
    {
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int potentialNeighborNode = currentSearchNode.coordinates + direction;
            
            if (grid.ContainsKey(potentialNeighborNode))
            {
                neighbors.Add(grid[potentialNeighborNode]);

                // TODO remove after testing
                grid[potentialNeighborNode].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
