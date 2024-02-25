using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchery : MonoBehaviour
{
    [SerializeField] private GameObject WorkerPrefab;
    [SerializeField] private float Cooldown;
    [SerializeField] private TrailManager TrailManager;
    private float LastSpawned;

    void Start()
    {
        LastSpawned = Time.time;
    }

    void Update()
    {
        if (Time.time - LastSpawned > Cooldown)
        {
            LastSpawned = Time.time;
            SpawnAnt();
        }
    }

    private void SpawnAnt()
    {
        GameObject newAnt = GameObject.Instantiate(WorkerPrefab, gameObject.transform);
        newAnt.GetComponent<WorkerScript>().trailManager = TrailManager;
    }
}
