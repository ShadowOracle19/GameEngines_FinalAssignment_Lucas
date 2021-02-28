using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeliverPotionBox : MonoBehaviour
{
    bool potionInBox;
    public bool readyToDeliverPotion;
    public Water water;
    PotionBottle potion;
    public float points = 100;
    Color potionColor;
    public float r, g, b, totalPoints;
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
            potion = other.gameObject.GetComponent<PotionBottle>();
            potionColor = potion.potionFillColor;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        potionInBox = false;
        potion = null;
        
    }

    public void DeliverPotion()
    {
        if(readyToDeliverPotion)
        {
            CalculateColors(potionColor, water.objective);
            
            Destroy(potion.gameObject);
            readyToDeliverPotion = false;
            potionInBox = false;
            SceneManager.LoadScene("Results");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void CalculateColors(Color c1, Color c2)
    {
        Color32 c132 = c1;
        Color32 c232 = c2;

        Debug.Log(c132.ToString());
        Debug.Log(c232.ToString());

        r = Mathf.Abs(c232.r - c132.r);
        g = Mathf.Abs(c232.g - c132.g);
        b = Mathf.Abs(c232.b - c132.b);
        totalPoints = r + g + b;

        PlayerPrefs.SetInt("Score", (int)totalPoints);

    }
   
}
