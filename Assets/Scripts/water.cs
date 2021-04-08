using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class water : MonoBehaviour
{
    public PotionBrewing potionBrewing;
    public GameObject ingredient;
    public GameObject icon;
    public Transform ingredientWindow;

    private void OnTriggerEnter(Collider other)
    {
        ingredient = other.gameObject;
        potionBrewing.OnWaterContact(ingredient);
        var iconGameObj = Instantiate(icon, ingredientWindow);
        iconGameObj.GetComponent<Image>().sprite = other.GetComponent<currentIngrediant>().getCurrentIngrediant().itemIcon;
    }
}
