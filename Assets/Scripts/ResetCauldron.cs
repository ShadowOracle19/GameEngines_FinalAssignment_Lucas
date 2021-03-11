using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCauldron : MonoBehaviour
{
    private InputManager inputManager;
    public GameObject resetCauldronWindow;
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
        if(inputManager.PlayerPressedReset())
        {
            if(isInRange)
            {
                cauldronWater.EmptyCauldron();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            resetCauldronWindow.SetActive(true);
            isInRange = true;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            resetCauldronWindow.SetActive(false);
            isInRange = false;
        }
            
    }
}
