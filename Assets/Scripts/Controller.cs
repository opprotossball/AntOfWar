using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private TrailManager trailManager;
    [SerializeField] private float maxSelectDist;
    private GameObject? selectedTrail;
    private Color selectedTrailColor = Color.red;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            trailManager.ResetColors();
            selectedTrail = trailManager.FindNearestTrail(pos, maxSelectDist);
            if (selectedTrail != null)
            {
                LineRenderer lr = selectedTrail.GetComponent<LineRenderer>();
                lr.startColor = selectedTrailColor; 
                lr.endColor = selectedTrailColor;
            }
        }
        if (Input.GetKeyDown(KeyCode.Delete) && selectedTrail != null) 
        { 
            trailManager.RemoveTrail(selectedTrail);
            selectedTrail = null;
        }
    }
}
