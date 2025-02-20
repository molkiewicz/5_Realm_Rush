﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    private Waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();

        transform.position = new Vector3(
            waypoint.GetGridPosition().x*gridSize,
            0f,
            waypoint.GetGridPosition().y*gridSize
            );
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPosition().x  + "," + waypoint.GetGridPosition().y;
        gameObject.name = "Cube " + labelText;
        textMesh.text = labelText;
    }
}
