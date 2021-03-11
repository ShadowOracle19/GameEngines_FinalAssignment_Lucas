using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverPotion : MonoBehaviour
{
    private InputManager inputManager;
    public GameObject deliverPotionWindow;
    public bool isInRange = false;
    public DeliverPotionBox potionBox;

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
                potionBox.readyToDeliverPotion = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            deliverPotionWindow.SetActive(true);
            isInRange = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            deliverPotionWindow.SetActive(false);
            isInRange = false;
        }
            
    }
}
