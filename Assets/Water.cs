using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Ingrediants ingrediant;

    public List<Ingrediants> currentIngrediantsAdded = new List<Ingrediants>();

    public Color currentColor;
    public Color originalColor;
    public GameObject PotionPrefab;
    public Transform potionSpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        currentColor = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        originalColor = currentColor;
    }

    // Update is called once per frame
    

    void OnTriggerEnter(Collider other)
    {
        ingrediant = other.GetComponent<currentIngrediant>().getCurrentIngrediant();
        currentIngrediantsAdded.Add(ingrediant);
        StartCoroutine(changeWaterColor());
        Destroy(other.gameObject, 1);
    }

    IEnumerator changeWaterColor()
    {
        yield return new WaitForSeconds(0.1f);
        currentColor = Color.Lerp(currentColor, ingrediant.color, 0.5f);
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", currentColor);
    }

    public void EmptyCauldron()
    {
        currentIngrediantsAdded.Clear();
        currentColor = originalColor;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", currentColor);
    }

    public void BrewPotion()
    {
        if(currentIngrediantsAdded.Count <= 2)
        {
            Instantiate(PotionPrefab, new Vector3(
                potionSpawnPoint.position.x, 
                potionSpawnPoint.position.y, 
                potionSpawnPoint.position.z), 
                Quaternion.identity );
            EmptyCauldron();
        }
    }
}
