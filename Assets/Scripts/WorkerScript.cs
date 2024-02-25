using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private static readonly float trailEps = 0.001f;
    public TrailManager trailManager;
    private Rigidbody2D rb;
    private TrailDto trail;
    private int nextNode;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = new TrailDto()
        {
            Trail = null,
            Forward = false,
        };
    }

    private void FindTrail()
    {
        if (trail.Trail == null)
        {
            trail = trailManager.FindNearestEnd(gameObject.transform.position);
            if (trail.Trail == null)
            {
                return;
            }
            if (trail.Forward)
            {
                nextNode = 1;
            } 
            else
            {
                nextNode = trail.Trail.GetComponent<LineRenderer>().positionCount - 1;
            }
        }
    }

    void FixedUpdate()
    {
        FindTrail();
        if (trail.Trail != null)
        {
            LineRenderer lr = trail.Trail.GetComponent<LineRenderer>();
            Vector3 target = lr.GetPosition(nextNode);
            transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
            if (Vector3.Distance(transform.position, target) < trailEps)
            {
                if (trail.Forward)
                {
                    nextNode++;
                }
                else
                {
                    nextNode--;
                }
                if (nextNode == -1)
                {
                    trail.Forward = true;
                    nextNode = 1;
                } 
                else if (nextNode == lr.positionCount)
                {
                    trail.Forward = false;
                    nextNode = lr.positionCount - 2;
                }
            }
        }
    }
}
