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
    public float goldGiven;
    public int skillPointsGiven;
    public TextMeshPro potionName;
    public TextMeshPro reward;
    public TextMeshPro amountNeededText;
    public TextMeshPro skillText;
    public GameObject potionIcon;
    public GameObject potionEffect;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        water = FindObjectOfType<PotionBrewing>();
        GiveTask();
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
                gameManager.TasksCompleted++;
                gameManager.skillPoints = skillPointsGiven;
                GiveTask();
            }
            else
            {
                var effect = Instantiate(potionEffect);
                effect.gameObject.transform.position = potion.gameObject.transform.position;
                effect.GetComponent<ParticleSystem>().Emit(1000);
                amountNeededText.text = "Amount Needed: " + amountNeeded.ToString();
                Destroy(potion.gameObject);
                readyToDeliverPotion = false;
                potionInBox = false;
                effect.GetComponent<ParticleSystem>().Stop();
            }
        }
        else if(readyToDeliverPotion)
        {
            var effect = Instantiate(potionEffect);
            effect.gameObject.transform.position = potion.gameObject.transform.position;
            effect.GetComponent<ParticleSystem>().Emit(1000);
            gameManager.money += potion.recipe.sellAmount;
            Destroy(potion.gameObject);
            readyToDeliverPotion = false;
            potionInBox = false;
            effect.GetComponent<ParticleSystem>().Stop();
        }
    }

    public void GiveTask()
    {
        randomPotion = Random.Range(0, water.recipies.Length);
        desiredPotion = water.recipies[randomPotion];
        amountNeeded = Random.Range(1, 3);
        skillPointsGiven = amountNeeded;
        goldGiven = Random.Range(25, 100);
        goldGiven = goldGiven * amountNeeded * (gameManager.potionSellAmountLevel / 10) + goldGiven;
        potionName.text = desiredPotion.itemName;
        potionIcon.GetComponent<SpriteRenderer>().sprite = desiredPotion.itemIcon;
        amountNeededText.text = "Amount Needed: " + amountNeeded.ToString();
        reward.text = "Reward: " + goldGiven.ToString();
        skillText.text = "Skill Points: " + skillPointsGiven.ToString();
    }
}
