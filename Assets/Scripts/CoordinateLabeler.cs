using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

// While making the build of the game, need to move this script to 
// "Editor" folder(if doesn't exists create one)

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.green;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro coordinatesLabel;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    private void Awake()
    {
        coordinatesLabel = GetComponent<TextMeshPro>();
        gridManager = FindObjectOfType<GridManager>();
        GetDisplayCoordinates();
        
    }
    // Had to restart the cycle by starting and stopping play 
    // So that it will update the coordinates in editor view correctly
    void Update()
    {
        if (!Application.isPlaying)
        {
            GetDisplayCoordinates();
            SetParentObjectName();
        }

        ColorCoordinates();
        Togglelabels();
    }

    void Togglelabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            coordinatesLabel.enabled = !coordinatesLabel.enabled;
        }
    }

    private void ColorCoordinates()
    {
        if (gridManager == null)
        {
            return;
        }

        Node node  = gridManager.GetNode(coordinates);

        if (node == null) { return; }

        if (!node.isWalkable)
        {
            coordinatesLabel.color = blockedColor;
        }else if (node.isPath)
        {
            coordinatesLabel.color = pathColor;
        }else if (node.isExplored)
        {
            coordinatesLabel.color = exploredColor;
        }else
        {
            coordinatesLabel.color = defaultColor;
        }
    }

    private void SetParentObjectName()
    {
        transform.parent.gameObject.name =  coordinatesLabel.text;
    }

    private void GetDisplayCoordinates()
    {
        if (gridManager == null) return;
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.y);
        coordinatesLabel.text = coordinates.x + " ," + coordinates.y;
    }
}
