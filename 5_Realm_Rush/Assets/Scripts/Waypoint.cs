using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
   
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPleaceable = true;

    Vector2Int gridPos;
    const int gridSize = 10;

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPleaceable)
        {
            FindObjectOfType<TowerFactory>().AddTower(this); 
        }
           
    }

    //public void SetTopColor(Color color)
    //{
    //    MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
    //    topMeshRenderer.material.color = color;
    //}
}
