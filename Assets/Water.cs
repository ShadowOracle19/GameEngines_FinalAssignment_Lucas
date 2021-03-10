using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public PotionBrewing potionBrewing;
    public GameObject ingredient;

    private void OnTriggerEnter(Collider other)
    {
        ingredient = other.gameObject;
        potionBrewing.OnWaterContact(ingredient);
    }
}
