using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MousePose : MonoBehaviour
{
    public Vector3 worldPosition;
    public Vector3 screenPose;

    // Update is called once per frame
    void Update()
    {
        screenPose = Input.mousePosition;
        screenPose.z = Camera.main.nearClipPlane + 1;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPose);



        transform.position = worldPosition;
    }
}

