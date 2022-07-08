using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Count_Text : MonoBehaviour
{
    private static Coin_Count_Text instance;
    private Text text;

    void Start()
    {
        instance = this;
        text = GetComponent<Text>();
        UpdateCountCoin();
    }
    public static void UpdateCountCoin()
    {
        if (instance != null)
            instance.text.text = PlayerStatistic.Coins.ToString();
    }
}
