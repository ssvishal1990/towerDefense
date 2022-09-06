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

    TextMeshPro coordinatesLabel;
    WayPoint wayPoint;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        coordinatesLabel = GetComponent<TextMeshPro>();
        wayPoint = GetComponentInParent<WayPoint>();
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
        if (wayPoint.CanPlace)
        {
            coordinatesLabel.color = defaultColor;
        }else
        {
            coordinatesLabel.color = blockedColor;
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
