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
    void Start()
    {
        Trails = new Queue<GameObject>();
    }

    void Update()
    {
        
    }
}
