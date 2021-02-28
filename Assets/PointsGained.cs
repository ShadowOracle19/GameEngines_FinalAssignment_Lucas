using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsGained : MonoBehaviour
{
    int playerPoints;
    public TextMeshProUGUI pointsGained;
    // Start is called before the first frame update
    void Awake()
    {
        playerPoints = PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPoints <= 10)
        {
            pointsGained.SetText("Wow I didn't think you can get here! S RANK!");
        }
        else if (playerPoints <= 50)
        {
            pointsGained.SetText("Congrats you matched the color right. A Rank!");
        }
        else if (playerPoints <= 100)
        {
            pointsGained.SetText("Almost got it we give you B Rank.");
        }
        else if (playerPoints <= 150)
        {
            pointsGained.SetText("Nice try. C Rank");
        }
        else if (playerPoints <= 200)
        {
            pointsGained.SetText("Try again. D Rank");
        }
        else
        {
            pointsGained.SetText("Were you even trying?!.. F Rank");
        }
        
    }
}
