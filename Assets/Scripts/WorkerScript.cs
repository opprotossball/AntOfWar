using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkerScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gatheringRate;
    [SerializeField] private float trailDetectionRange;
    private static readonly float trailEps = 0.001f;
    public TrailManager trailManager;
    private Rigidbody2D rb;
    private TrailDto trail;
    private int nextNode;
    private float food;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = new TrailDto()
        {
            Trail = null,
            Forward = false,
        };
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        GameObject other = collision.gameObject;
        if (other.GetComponent<FoodScript>() != null)
        {
            food = other.GetComponent<FoodScript>().Gather(gatheringRate);
        }
        else if (other.GetComponent<Hatchery>() != null)
        {
            other.GetComponent<Hatchery>().AddFood(food);
            food = 0;
        }
    }

    private void FindTrail()
    {
        if (trail.Trail == null)
        {
            TrailDto newTrail = trailManager.FindNearestEnd(gameObject.transform.position);
            if (newTrail.Trail == null)
            {
                return;
            }
            LineRenderer lr = newTrail.Trail.GetComponent<LineRenderer>();
            if (newTrail.Forward)
            {
                if (Vector3.Distance(transform.position, lr.GetPosition(0)) > trailDetectionRange)
                {
                    return;
                }
                nextNode = 1;
            } 
            else
            {
                if (Vector3.Distance(transform.position, lr.GetPosition(lr.positionCount - 1)) > trailDetectionRange)
                {
                    return;
                }
                nextNode = lr.positionCount - 1;
            }
            trail = newTrail;
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
