using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Ingrediants ingrediant;

    public List<Ingrediants> currentIngrediantsAdded = new List<Ingrediants>();

    public Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        currentColor = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        ingrediant = other.GetComponent<currentIngrediant>().getCurrentIngrediant();
        currentIngrediantsAdded.Add(ingrediant);
        StartCoroutine(changeWaterColor());
        Destroy(other, 1);
    }

    IEnumerator changeWaterColor()
    {
        yield return new WaitForSeconds(0.1f);
        currentColor = Color.Lerp(currentColor, ingrediant.color, 1f);
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", currentColor);
    }
}
