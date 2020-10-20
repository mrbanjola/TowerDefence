using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldBlock : MonoBehaviour
{
    int gridSize = 10;

    public bool isExplored = false;
    public bool isPlaceable = true;

    public WorldBlock exploredFrom;

    TowerFactory towerFactory; 

    // Start is called before the first frame update
    void Start()
    {
        towerFactory = FindObjectOfType<TowerFactory>();
    }

    public Vector3Int GetGridPos()
    {
        return new Vector3Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.y / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize));

    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public void SetTopColor(Color color)
    {
        var topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                towerFactory.AddTower(gameObject.GetComponent<WorldBlock>());
            }
            else
            {
                print(string.Format("You can't place a tower at {0}", gameObject.name));
            }
           
        } 
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
