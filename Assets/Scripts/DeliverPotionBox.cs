using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeliverPotionBox : MonoBehaviour
{
    bool potionInBox;
    public bool readyToDeliverPotion;
    public PotionBrewing water;
    PotionBottle potion;


    private GameManager gameManager;

    [Header("Task")]
    public Recipies desiredPotion;
    public int randomPotion;
    public int amountNeeded;
    public int goldGiven;
    public TextMeshPro potionName;
    public TextMeshPro reward;
    public TextMeshPro amountNeededText;
    public GameObject potionIcon;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        water = FindObjectOfType<PotionBrewing>();
        randomPotion = Random.Range(0, water.recipies.Length);
        desiredPotion = water.recipies[randomPotion];
        amountNeeded = Random.Range(1, 3);
        goldGiven  = Random.Range(25, 100) * amountNeeded;
        potionName.text = desiredPotion.itemName;
        reward.text = "Reward: " + goldGiven.ToString();
        potionIcon.GetComponent<SpriteRenderer>().sprite = desiredPotion.itemIcon;
        amountNeededText.text = "Amount Needed: " + amountNeeded.ToString();
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
        if(readyToDeliverPotion && potion.recipe == desiredPotion)
        {
            amountNeeded -= 1;
            if(amountNeeded == 0)
            {
                //reset task
                //give reward
                gameManager.money += goldGiven;
                GiveTask();
            }
            else
            {
                amountNeededText.text = "Amount Needed: " + amountNeeded.ToString();
                Destroy(potion.gameObject);
                readyToDeliverPotion = false;
                potionInBox = false;
            }
        }
        else if(readyToDeliverPotion)
        {            
            gameManager.money += potion.recipe.sellAmount;
            Destroy(potion.gameObject);
            readyToDeliverPotion = false;
            potionInBox = false;
        }
    }

    public void GiveTask()
    {
        randomPotion = Random.Range(0, water.recipies.Length);
        desiredPotion = water.recipies[randomPotion];
        amountNeeded = Random.Range(1, 3);
        goldGiven = Random.Range(25, 100) * amountNeeded;
        potionName.text = desiredPotion.itemName;
        reward.text = "Reward: " + goldGiven.ToString();
        potionIcon.GetComponent<SpriteRenderer>().sprite = desiredPotion.itemIcon;
        amountNeededText.text = "Amount Needed: " + amountNeeded.ToString();
    }
}
