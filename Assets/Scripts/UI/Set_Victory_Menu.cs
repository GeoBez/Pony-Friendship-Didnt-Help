using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Victory_Menu : MonoBehaviour
{
    public GameObject Victory_Menu;
    public YandexSDK YandexSDK;

    private WaveController _waveController;
    private void Start()
    {
        //Victory_Menu = GameObject.FindGameObjectWithTag("Victory Menu");
        Victory_Menu.SetActive(false);
<<<<<<< Updated upstream
        //number_Of_Enemies = GameObject.FindGameObjectWithTag("Wave System").GetComponent<Wave_System>();
        _waveController = GameObject.FindGameObjectWithTag("Wave Controller").GetComponent<WaveController>();

        /*for (int i = 0; i < number_Of_Enemies.number_Of_Enemies.Length; i++)
        {
            all_Enemies += number_Of_Enemies.number_Of_Enemies[i];
        }*/

=======
        _waveController = GameObject.FindGameObjectWithTag("Wave Controller").GetComponent<WaveController>();

>>>>>>> Stashed changes
        /*YandexSDK = YandexSDK.instance;
        YandexSDK.ShowInterstitial();*/
    }

    private void Update()
    {   
        if (WaveController.Wave_Number == _waveController.Waves.Length-1 && WaveController.NeedToKill == 0)
        {
            Victory_Menu.SetActive(true);
        }
    }
}
