using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Victory_Menu : MonoBehaviour
{
    public Wave_System number_Of_Enemies;
    public GameObject Victory_Menu;
    public int all_Enemies;

    private WaveController _waveController;
    private void Start()
    {
        Victory_Menu = GameObject.FindGameObjectWithTag("Victory Menu");
        Victory_Menu.SetActive(false);
        number_Of_Enemies = GameObject.FindGameObjectWithTag("Wave System").GetComponent<Wave_System>();
        _waveController = GameObject.FindGameObjectWithTag("Wave Controller").GetComponent<WaveController>();

        for (int i = 0; i < number_Of_Enemies.number_Of_Enemies.Length; i++)
        {
            all_Enemies += number_Of_Enemies.number_Of_Enemies[i];
        }
    }

    private void Update()
    {
        /*if (all_Enemies <= 0)
        {
            Victory_Menu.SetActive(true);
        }*/
        
        if (WaveController.Wave_Number == _waveController.Waves.Length-1 && WaveController.NeedToKill == 0)
        {
            Victory_Menu.SetActive(true);
        }
    }
}
