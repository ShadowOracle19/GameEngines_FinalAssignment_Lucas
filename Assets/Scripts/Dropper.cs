using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dropper : MonoBehaviour
{
    public Ingrediants ingrediantToDrop;
    public Transform spawnerDropPoint;
    public float price;
    public GameManager gameManager;
    public TextMeshPro priceText;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(price >= gameManager.money)
            {
                //do nothing
            }
            else
            {
                gameManager.money -= price; 
                Instantiate(ingrediantToDrop.ingrediantPrefab, spawnerDropPoint.transform.position, Quaternion.identity);
                if(Random.value <= gameManager.ingredientDoubleSpawnChance / 10)
                {
                    Instantiate(ingrediantToDrop.ingrediantPrefab, spawnerDropPoint.transform.position, Quaternion.identity);

                }
            }
        }
    }

    void Update()
    {
        
        priceText.text = ingrediantToDrop.itemName + " \n$" + price.ToString();
    }

}
