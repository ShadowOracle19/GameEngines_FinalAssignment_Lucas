using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float money;
    public float TasksCompleted;
    public float skillPoints;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI taskText;
    public TextMeshProUGUI skillText;

    [Header("Player Level")]
    public float ingredientCostLevel;
    public float ingredientDoubleSpawnChance;
    public float potionSellAmountLevel;
    public TextMeshProUGUI ingredientCostLevelText;
    public TextMeshProUGUI ingredientDoubleSpawnChanceText;
    public TextMeshProUGUI potionSellAmountLevelText;
    public Dropper[] droppers;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }
    private void Start()
    {
        droppers = FindObjectsOfType<Dropper>();
        Load();

    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        goldText.SetText("Gold: " + money.ToString());
        PlayerPrefs.SetFloat("Gold", money);

        taskText.SetText("Tasks Completed: " + TasksCompleted.ToString());
        PlayerPrefs.SetFloat("TaskCompleted", TasksCompleted);

        skillText.SetText("Skill Points: " + skillPoints.ToString());
        PlayerPrefs.SetFloat("SkillPoints", skillPoints);

        ingredientCostLevelText.SetText("Ingredient Cost Discount: " + ingredientCostLevel.ToString());
        PlayerPrefs.SetFloat("ingredientCostLevel", ingredientCostLevel);

        ingredientDoubleSpawnChanceText.SetText("Ingredient Double Spawn Chance: " + ingredientDoubleSpawnChance.ToString());
        PlayerPrefs.SetFloat("ingredientDoubleSpawnChance", ingredientDoubleSpawnChance);

        potionSellAmountLevelText.SetText("Potion Sell Increase: " + potionSellAmountLevel.ToString());
        PlayerPrefs.SetFloat("potionSellAmountLevel", potionSellAmountLevel);
    }

    public void upgradeIngredientDiscount()
    {
        if(skillPoints >= 1)
        {
            ingredientCostLevel += 1;
            skillPoints -= 1;

            foreach (var item in droppers)
            {
                item.price = item.price - (item.price * (ingredientCostLevel / 100));
            }
        }
    }
    public void upgradeDoubleSpawn()
    {
        if (skillPoints >= 1)
        {
            ingredientDoubleSpawnChance += 1;
            skillPoints -= 1;
        }
    }
    public void upgradeSellAmount()
    {
        if (skillPoints >= 1)
        {
            potionSellAmountLevel += 1;
            skillPoints -= 1;
        }
    }

    void Load()
    {

        money = PlayerPrefs.GetFloat("Gold");
        if (money == 0)
        {
            money = 150;
            PlayerPrefs.SetFloat("Gold", money);
        }
        TasksCompleted = PlayerPrefs.GetFloat("TaskCompleted");
        skillPoints = PlayerPrefs.GetFloat("SkillPoints"); ;
        ingredientCostLevel = PlayerPrefs.GetFloat("ingredientCostLevel"); ;
        ingredientDoubleSpawnChance = PlayerPrefs.GetFloat("ingredientDoubleSpawnChance"); ;
        potionSellAmountLevel = PlayerPrefs.GetFloat("potionSellAmountLevel"); ;
    }
}
