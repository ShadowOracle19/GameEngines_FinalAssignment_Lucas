using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverPotionBox : MonoBehaviour
{
    bool potionInBox;
    public bool readyToDeliverPotion;
    public Water water;
    GameObject potion;
    public float points = 100;
    Color potionColor;
    // Start is called before the first frame update
    void Start()
    {
        water = FindObjectOfType<Water>();
    }

    // Update is called once per frame
    void Update()
    {
        if(potionInBox)
        {
            DeliverPotion();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Potion"))
        {
            potionInBox = true;
            potion = other.gameObject;
            potionColor = potion.GetComponent<Renderer>().material.GetColor("_Color");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        potionInBox = false;
        potion = null;
        potionColor = Color.white;
    }

    public void DeliverPotion()
    {
        if(readyToDeliverPotion)
        {
            CalculateColors(potionColor, water.objective);
            Debug.Log(points.ToString());
            Destroy(potion, 2);
            readyToDeliverPotion = false;
            potionInBox = false;
        }
    }

    public void CalculateColors(Color c1, Color c2)
    {
        Color32 c132 = c1;
        Color32 c232 = c2;
        
        points = (c132.r - c232.r) + (c132.g - c232.g) + (c132.b - c232.b);
    }
   
}
