using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int money = 0;
    public TextMeshProUGUI goldText;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }
    private void Start()
    {
        money = PlayerPrefs.GetInt("Gold");
        if (money == 0)
        {
            money = 150;
            PlayerPrefs.SetInt("Gold", money);
        }
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
    }
}
