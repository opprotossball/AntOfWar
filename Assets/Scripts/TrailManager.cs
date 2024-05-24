using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    [SerializeField] private int MaxTrails;
    private readonly Color trailColor = Color.white;
    private LinkedList<GameObject> Trails;

    public void AddTrail(GameObject trail)
    {
        Debug.Log("Added Trail");
        while (Trails.Count >= MaxTrails)
        {
            GameObject go = Trails.First.Value;
            Trails.RemoveFirst();
            Destroy(go);
        }
        Trails.AddLast(trail);
    }

    public TrailDto FindNearestEnd(Vector3 pos)
    {
        GameObject? nearest = null;
        bool forward = false;
        float minDist = float.MaxValue;
        foreach (GameObject trail in Trails)
        {
            LineRenderer lr = trail.GetComponent<LineRenderer>();
            float db = Vector3.Distance(pos, lr.GetPosition(0));
            if (db < minDist)
            {
                nearest = trail;
                forward = true;
                minDist = db;
            }
            int end = lr.positionCount - 1;
            float de = Vector3.Distance(pos, lr.GetPosition(end));
            if (de < minDist)
            {
                nearest = trail;
                forward = false;
                minDist = de;
            }
        }
        return new TrailDto()
        {
            Trail = nearest,
            Forward = forward
        };
    }

    public void ResetColors()
    {
        foreach (GameObject trail in Trails)
        {
            LineRenderer lineRenderer = trail.GetComponent<LineRenderer>();
            lineRenderer.startColor = trailColor; 
            lineRenderer.endColor = trailColor;
        }
    }

    public GameObject? FindNearestTrail(Vector3 pos, float maxDist)
    {
        GameObject? nearest = null;
        float minDist = float.MaxValue;
        foreach (GameObject trail in Trails)
        {
            LineRenderer lr = trail.GetComponent<LineRenderer>();
            for (int i = 0; i < lr.positionCount; i++)
            {
                float dist = Vector3.Distance(pos, lr.GetPosition(i));
                if (dist < minDist && dist < maxDist)
                {
                    nearest = trail;
                    minDist = dist;
                }
            }
        }
        return nearest;
    }

    public void RemoveTrail(GameObject trail)
    {
        LinkedList<GameObject> newList = new LinkedList<GameObject>();
        foreach (GameObject t in Trails)
        {
            if (t != trail) newList.AddLast(t);
        }
        Trails = newList;
        Destroy(trail);
        trail = null;
    }

    void Start()
    {
        Trails = new LinkedList<GameObject>();
    }

    void Update()
    {
        
    }
}
