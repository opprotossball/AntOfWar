using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchery : MonoBehaviour
{
    [SerializeField] private GameObject WorkerPrefab;
    [SerializeField] private float Cooldown;
    private float LastSpawned;

    // Start is called before the first frame update
    void Start()
    {
        LastSpawned = Time.time;
    }

    // Update is called once per frame
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
        GameObject.Instantiate(WorkerPrefab, gameObject.transform);
    }
}
