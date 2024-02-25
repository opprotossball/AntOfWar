using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    [SerializeField] private int MaxTrails;
    private Queue<GameObject> Trails;

    public void AddTrail(GameObject trail)
    {
        Debug.Log("Added Trail");
        while (Trails.Count >= MaxTrails)
        {
            GameObject go = Trails.Dequeue();
            Destroy(go);
        }
        Trails.Enqueue(trail);
    }

    public TrailDto FindNearestEnd(Vector3 pos)
    {
        GameObject? nearest = null;
        bool forward = false;
        float minDist = float.MaxValue;
        foreach (GameObject trail in Trails.ToArray())
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

    void Start()
    {
        Trails = new Queue<GameObject>();
    }

    void Update()
    {
        
    }
}
