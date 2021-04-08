using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RecipeBook : MonoBehaviour
{
    public PotionBrewing potionBrewing;
    public GameObject buttonPrefab;
    public GameObject potionButtonsWindow;
    public GameObject ingredientListWindow;
    public GameObject ingredientTextPrefab;
    public GameObject[] buttons;
    public GameObject recipeWindow;
    public bool recipeWindowActive = false;

    private InputManager inputManager;

    private void Start()
    {
        recipeWindow.SetActive(recipeWindowActive);
        inputManager = InputManager.Instance;
        buttons = new GameObject[potionBrewing.recipies.Length];
        for (int i = 0; i < potionBrewing.recipies.Length; i++)
        {
            buttons[i] = Instantiate(buttonPrefab, potionButtonsWindow.transform);
            buttons[i].name = potionBrewing.recipies[i].itemName;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = potionBrewing.recipies[i].itemName;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            buttons[closureIndex].GetComponent<Button>().onClick.AddListener(() => TaskOnClick(closureIndex));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(inputManager.PlayerPressedTab())
        {

            recipeWindowActive = !recipeWindowActive;
            if (recipeWindowActive == true)
            {
                Time.timeScale = 0.00001f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
            recipeWindow.SetActive(recipeWindowActive);
            
        }
    }

    public void TaskOnClick(int buttonIndex)
    {
        foreach (Transform child in ingredientListWindow.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int i = 0; i < potionBrewing.recipies[buttonIndex].ingrediants.Count; i++)
        {
            var ingredientText = Instantiate(ingredientTextPrefab, ingredientListWindow.transform);
            ingredientText.GetComponent<TextMeshProUGUI>().text = "- " + potionBrewing.recipies[buttonIndex].ingrediants[i].itemName;
            ingredientText.GetComponentInChildren<Image>().sprite = potionBrewing.recipies[buttonIndex].ingrediants[i].itemIcon;
        }

    }
}
