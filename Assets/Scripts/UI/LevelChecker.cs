using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChecker : MonoBehaviour
{
    public XP_Bar xP_Bar;
    private Text textLevel;

    void Start()
    {
        textLevel = GetComponent<Text>(); 
    }
    void Update()
    {
        if (PlayerPrefs.HasKey("Level")) textLevel.text = $"Lv. {PlayerPrefs.GetInt("Level")}";
        else textLevel.text = $"Lv. {xP_Bar.level}";
    }
}
