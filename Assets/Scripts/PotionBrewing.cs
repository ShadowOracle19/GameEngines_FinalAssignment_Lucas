using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionBrewing : MonoBehaviour
{
    public static PotionBrewing _instance;
    public Ingrediants ingrediant;
    public List<Ingrediants> currentIngrediantsAdded = new List<Ingrediants>();
    public Color currentColor;
    public Color originalColor;
    public GameObject PotionPrefab;
    public Transform potionSpawnPoint;
    public Color32 objective;
    public Transform spawnPoint;
    public Recipies[] recipies;
    public bool isRecipeCorrect;
    public GameObject cauldronWater;

    public static PotionBrewing Instance
    {
        get { return _instance; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentIngrediantsAdded.Sort(
            delegate(Ingrediants i1, Ingrediants i2)
            {
                return i1.itemName.CompareTo(i2.name);
            }
            
            );

        
    }

    public void OnWaterContact(GameObject other)
    {
        if (other.CompareTag("Ingredient"))
        {
            ingrediant = other.GetComponent<currentIngrediant>().getCurrentIngrediant();
            currentIngrediantsAdded.Add(ingrediant);
            StartCoroutine(changeWaterColor());
            Destroy(other);
        }
        else if (other.CompareTag("Player"))
        {
            other.transform.position = spawnPoint.transform.position;
        }
        else if (other.CompareTag("Potion"))
        {
            Destroy(other);
        }
    }

    IEnumerator changeWaterColor()
    {
        yield return new WaitForSeconds(0.1f);
        currentColor = Color.Lerp(currentColor, ingrediant.color, 0.5f);
        cauldronWater.GetComponent<Renderer>().material.SetColor("_Color", currentColor);
    }

    public void EmptyCauldron()
    {
        currentIngrediantsAdded.Clear();
        currentColor = originalColor;
        cauldronWater.GetComponent<Renderer>().material.SetColor("_Color", currentColor);
    }

    public void BrewPotion()
    {
        
        for (int i = 0; i < recipies.Length; i++)//goes through the list of recipies
        {
            
            for (int j = 0; j < recipies[i].ingrediants.Count; j++)//cycles through the ingredients list and checks if the ingredients match
            {
                
                if (recipies[i].ingrediants[j].itemName != currentIngrediantsAdded[j].itemName)//checks if the ingredient is right
                {
                    isRecipeCorrect = false;
                    break;
                }
                isRecipeCorrect = true;
            }
            
            if (isRecipeCorrect)
            {              
                Instantiate(recipies[i].finalProductPrefab, new Vector3(
                    potionSpawnPoint.position.x, 
                    potionSpawnPoint.position.y, 
                    potionSpawnPoint.position.z), 
                    Quaternion.identity );

                EmptyCauldron();
                break;
            }
        }
        
    }
}
