using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Potions/Potions")]
public class Recipies : Item
{
    [Header("Recipe")]
    public List<Ingrediants> ingrediants = new List<Ingrediants>();

    [Header("Final Potion Attributes")]
    public int sellAmount;
    public GameObject finalProductPrefab;

    private void Awake()
    {
        ingrediants.Sort(
            delegate (Ingrediants i1, Ingrediants i2)
            {
                return i1.itemName.CompareTo(i2.name);
            }

            );
    }
}
