using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class Hatchery : MonoBehaviour
{   

    [SerializeField] private GameObject WorkerPrefab;
    [SerializeField] private float baseCooldown = 10.0f;
    private float currentCooldown;
    [SerializeField] TMP_Text foodText;
    [SerializeField] TrailManager TrailManager;
    [SerializeField] private float startFood = 100f;
    private float currentFood;

    void Start()
    {
        currentCooldown = baseCooldown;
        currentFood = startFood;
        StartCoroutine(SpawnAntRoutine());
        UpdateFoodText();
    }

    void Update()
    {

    }

    IEnumerator SpawnAntRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentCooldown);
            if (currentFood > 0)
            {
                SpawnAnt();
                currentFood--;
                UpdateCooldown();
                UpdateFoodText();
            }
            else
            {
                Debug.Log("No food available!");
            }
        }
    }

    private void SpawnAnt()
    {
        GameObject newAnt = GameObject.Instantiate(WorkerPrefab, gameObject.transform);
        newAnt.GetComponent<WorkerScript>().trailManager = TrailManager;
    }

    private void UpdateCooldown()
    {
        currentCooldown = baseCooldown / Mathf.Min(10f, currentFood / startFood);
    }

    public void AddFood(float amount)
    {
        currentFood += amount;
        UpdateCooldown();
        UpdateFoodText();
    }

    private void UpdateFoodText()
    { 
        foodText.text = currentFood.ToString();
    }
}
