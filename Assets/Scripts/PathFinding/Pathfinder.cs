using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int endCoordinates;


    Node startNode;
    Node endNode;
    Node currentSearchNode;
    
    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reachedDictionary = new Dictionary<Vector2Int, Node>();

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
        startNode = new Node(startCoordinates, true);
        endNode = new Node(endCoordinates, true);
    }

    private void Start()
    {
        breadthFirstSearch();
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
            }
        }

        foreach (Node neighbor in neighbors)
        {
            if (!reachedDictionary.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                reachedDictionary.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    void breadthFirstSearch()
    {
        bool isRunning = true;
        frontier.Enqueue(startNode);
        reachedDictionary.Add(startCoordinates, startNode);

        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if (currentSearchNode.coordinates == endCoordinates)
            {
                isRunning = false;
            }
        }
    }
}
