using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] private float FoodLeft;
    [SerializeField] private TMP_Text Text;

    public float Gather(float maxAmount)
    {
        float res = Mathf.Min(FoodLeft, maxAmount);
        FoodLeft -= res;
        Text.SetText(FoodLeft.ToString());
        if (FoodLeft <= 0)
        {
            Destroy(gameObject);
        }
        return res;
    }
}
