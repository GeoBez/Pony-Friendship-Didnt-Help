using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_Game_Over : MonoBehaviour
{
    static Set_Game_Over instance;
    public GameObject GameOverMenu;
    public YandexSDK YandexSDK;


    private void Start()
    {
        instance = this;
        //GameOverMenu = GameObject.FindGameObjectWithTag("GameOver");
        GameOverMenu.SetActive(false);

        /*YandexSDK = YandexSDK.instance;
        YandexSDK.ShowInterstitial();*/
    }

    public static void SetActive()
    {
        instance.GameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}

      
