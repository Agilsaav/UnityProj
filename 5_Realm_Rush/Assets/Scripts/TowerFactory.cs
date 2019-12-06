using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 3;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTrasnform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;
        if(numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTrasnform;
        baseWaypoint.isPleaceable = false;
        newTower.baseWaypoint = baseWaypoint;
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newbaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPleaceable = true;
        newbaseWaypoint.isPleaceable = false;

        oldTower.baseWaypoint = newbaseWaypoint;
        oldTower.transform.position = newbaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }

}
