using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBottle : MonoBehaviour
{
    public Water water;
    public GameObject potionFill;
    public Color potionFillColor;
    void Awake()
    {
        water = FindObjectOfType<Water>();
        potionFill.GetComponent<Renderer>().material.SetColor("_Color", water.currentColor);
        potionFillColor = water.currentColor;
    }
}
