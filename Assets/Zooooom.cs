using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineVirtualCamera virtualCamera;
    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 15f;


    // Update is called once per frame
    void Update()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float newZoom = virtualCamera.m_Lens.OrthographicSize - scroll * zoomSpeed;
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);
        virtualCamera.m_Lens.OrthographicSize = newZoom;
    }
}
