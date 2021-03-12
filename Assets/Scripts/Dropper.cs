using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public Ingrediants ingrediantToDrop;
    public Transform spawnerDropPoint;
    public int price;
    public GameManager gameManager;
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
            }
        }
    }
    
}
