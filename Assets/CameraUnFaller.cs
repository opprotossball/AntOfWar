using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLockCameraZMovement : MonoBehaviour 
{
    public float lockedZPosition = -2f;

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.z = lockedZPosition;    
        transform.position = currentPosition;

    }
}
