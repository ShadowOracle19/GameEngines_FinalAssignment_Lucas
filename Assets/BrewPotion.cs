using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewPotion : MonoBehaviour
{
    private InputManager inputManager;
    public GameObject brewPotionWindow;
    public bool isInRange = false;
    public PotionBrewing cauldronWater;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.PlayerPressedReset())
        {
            if (isInRange)
            {
                cauldronWater.BrewPotion();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        brewPotionWindow.SetActive(true);
        isInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        brewPotionWindow.SetActive(false);
        isInRange = false;
    }
}
