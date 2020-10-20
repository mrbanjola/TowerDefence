using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WorldBlock))]

public class CubeEditor : MonoBehaviour
{

    WorldBlock worldBlock;



    private void Awake()
    {
       worldBlock = GetComponent<WorldBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();

    }

    void SnapToGrid()
    {
        int gridSize = worldBlock.GetGridSize();
        transform.position = worldBlock.GetGridPos() * gridSize;
    }




    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = worldBlock.GetGridSize();
        Vector3Int snapPos = worldBlock.GetGridPos();
        string labelText = snapPos.x + "," + snapPos.z;
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = ""; //labelText;
        gameObject.name = string.Format("WorldBlock   ({0})", labelText);
    }
}
