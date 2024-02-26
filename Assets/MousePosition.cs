using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 worldPosition;
    public Vector3 screenPosition;

    
    void Update()
    {
        Vector3 screenPosition = Input.mousePosition;
        
        screenPosition.z = Camera.main.nearClipPlane;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;
    }
}
