using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeliverPotionBox : MonoBehaviour
{
    bool potionInBox;
    public bool readyToDeliverPotion;
    public PotionBrewing water;
    PotionBottle potion;
    public float points = 100;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        water = FindObjectOfType<PotionBrewing>();
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
            Destroy(potion.gameObject);
            readyToDeliverPotion = false;
            potionInBox = false;
            gameManager.money += 10;
        }
    }
}
