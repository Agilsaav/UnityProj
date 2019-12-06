using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {

    }
    public List<Waypoint> GetPath()
    {
        if(path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearch();
            CreatePath();
        }

        return path;
    }

    private void CreatePath()
    {
        SetAsPath(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while( previous != startWaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;

        }

        SetAsPath(startWaypoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPleaceable = false;
    }
    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeightbours();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
            isRunning = false;

    }

    private void ExploreNeightbours()
    {
        if (!isRunning) return;

        foreach( Vector2Int direction in directions)
        {
            Vector2Int neightbourCoordinates = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(neightbourCoordinates))
            {
                QueueNewNeighbours(neightbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neightbourCoordinates)
    {
        Waypoint neighbour = grid[neightbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour)) return;
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    //private void ColorStartAndEnd()
    //{
    //    startWaypoint.SetTopColor(Color.green);
    //    endWaypoint.SetTopColor(Color.red);
    //}

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();

        foreach( Waypoint waypoint in waypoints)
        {           
            if (grid.ContainsKey(waypoint.GetGridPos()))
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
