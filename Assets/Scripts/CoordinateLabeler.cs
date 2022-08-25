using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro coordinatesLabel;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        coordinatesLabel = GetComponent<TextMeshPro>();
        GetDisplayCoordinates();
    }
    void Start()
    {
        
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
    }

    private void SetParentObjectName()
    {
        transform.parent.gameObject.name =  coordinatesLabel.text;
    }

    private void GetDisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        coordinatesLabel.text = coordinates.x + " ," + coordinates.y;
    }
}
