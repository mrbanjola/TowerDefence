using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathFinder : MonoBehaviour
{
    Dictionary<Vector3Int, WorldBlock> grid = new Dictionary<Vector3Int, WorldBlock>();
    Queue<WorldBlock> queue = new Queue<WorldBlock>();
    public List<Vector3Int> path = new List<Vector3Int>();

    [Header("Path Start & End point")]
    [SerializeField] WorldBlock startpoint;
    [SerializeField] WorldBlock endpoint;

    WorldBlock searchCenter;
    WorldBlock goal;

    Color32 pathcolor = new Color(135f, 103f, 30f);

    Vector3Int[] directions =
    {
        new Vector3Int(0,0,1),
        new Vector3Int(1,0,0),
        new Vector3Int(-1,0,0),
        new Vector3Int(0,0,-1)


    };

    // Start is called before the first frame update
   
    private void SetStartEnd()
    {
        startpoint.SetTopColor(Color.green);
        endpoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var worldBlocks = FindObjectsOfType<WorldBlock>();
        foreach (WorldBlock worldBlock in worldBlocks)
        {
            bool isOverlaping = grid.ContainsKey(worldBlock.GetGridPos());

            if (!isOverlaping)
            {
                grid.Add(worldBlock.GetGridPos(), worldBlock);
            } else
            {
                Debug.LogFormat("Overlapping block: {0}", worldBlock.name);
            }
            

        }
        print(string.Format("Loaded {0} world blocks.",grid.Count));
    }


    void ExploreNeighbours()
    {
        foreach (Vector3Int direction in directions)
        {
            Vector3Int ExploringCoordinates = searchCenter.GetGridPos() + direction;

            QueueNewNeighbour(ExploringCoordinates);
        }
    }

    private void QueueNewNeighbour(Vector3Int ExploringCoordinates)
    {
        if (grid.ContainsKey(ExploringCoordinates)) // If there is a block at coordinates
        {
            if (!grid[ExploringCoordinates].isExplored || queue.Contains(grid[ExploringCoordinates])) // If it hasn't been explored
            {
                
                queue.Enqueue(grid[ExploringCoordinates]);
                grid[ExploringCoordinates].exploredFrom = searchCenter;
            }
        }
    }

    private void PathFind()
    {
        queue.Enqueue(startpoint);

        while (queue.Count > 0)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;

           
            if (GoalFound(searchCenter))
            {
                searchCenter.SetTopColor(Color.red);
                print("Goal found");
                goal = searchCenter;
                break;
            }
            ExploreNeighbours();
        }
    }

    bool GoalFound(WorldBlock current)
    {
        return (endpoint == current);
    }




    public List<Vector3Int> getPath()
    {
        if (path.Count == 0)

        {
            LoadBlocks();
            SetStartEnd();
            PathFind();
            CalculatePathToGoal();
            return path;
        }
        else
        {
           
            return path;
            
        }
        

    }

    private void CalculatePathToGoal()
    {
        path.Add(goal.GetGridPos());

        while (goal.exploredFrom != null)
        {

            path.Add(goal.exploredFrom.GetGridPos());
           
            goal = goal.exploredFrom;
            goal.SetTopColor(Color.black);
            goal.isPlaceable = false;


        }

        endpoint.isPlaceable = false;
        path.Reverse();
        
    }

    void Update()
    {
        
    }
}
