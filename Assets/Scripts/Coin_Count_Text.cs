using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Count_Text : MonoBehaviour
{
    public static int coin_Count=0;
    private Text text;

    void Start()
    {
        coin_Count = 0;
        text = GetComponent<Text>();        
    }
    void Update()
    {
        text.text = coin_Count.ToString();    
    }
}
