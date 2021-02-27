using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public Ingrediants ingrediantToDrop;
    public Transform spawnerDropPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(ingrediantToDrop.ingrediantPrefab, spawnerDropPoint.transform.position, Quaternion.identity);
        }
    }
}
