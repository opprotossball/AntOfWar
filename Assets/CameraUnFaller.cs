using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CLockCameraZMovement : MonoBehaviour 
{
    public float lockedZPosition = -2f;
    private string backgroundTag = "background";
    private Vector3 sizeInWorldUnits;

    void Start()
    {
        GameObject background = GameObject.FindGameObjectWithTag(backgroundTag);
        Tilemap tilemap = background.GetComponent<Tilemap>();
        BoundsInt cellBounds = tilemap.cellBounds;
        Vector3Int sizeInCells = cellBounds.size;
        Vector3 cellSize = tilemap.cellSize;
        sizeInWorldUnits = Vector3.Scale(sizeInCells, cellSize);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.z = lockedZPosition;
        float xBoundary = (sizeInWorldUnits.x / 2) - 25;
        float yBoundary = (sizeInWorldUnits.y / 2) - 5;

        if(currentPosition.x > xBoundary)
        {
            currentPosition.x = xBoundary;
        }
        else if (currentPosition.x < -1 * xBoundary)
        {
            currentPosition.x = -1 * (xBoundary -5);
        }
        if(currentPosition.y > yBoundary )
        {
            currentPosition.y = yBoundary;
        }
   
        else if(currentPosition.y < -1 * yBoundary )
        {
            currentPosition.y = -1 * (yBoundary - 10);
        }

        transform.position = currentPosition;
    }
}
