using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_System : MonoBehaviour
{
    public int Wave_Number;
    public int[] number_Of_Enemies;
    public int[] number_Of_Existed_Enemies;
    public Preparation_Script preparation;

    public void Start()
    {
        preparation = GameObject.FindGameObjectWithTag("Preparation").GetComponent<Preparation_Script>();
        Wave_Number = 0;

        Array.Resize(ref number_Of_Existed_Enemies, number_Of_Enemies.Length);  //опасный участок, если надо что-то добавить, добавляйте до него

        for (int i = 0; i < number_Of_Enemies.Length; i++)
        {
            number_Of_Enemies.CopyTo(number_Of_Existed_Enemies, i);
        }
    }

    public void Rise_Wave_Number()
    {
        if (Wave_Number == number_Of_Enemies.Length)
                gameObject.SetActive(false);
        else if (number_Of_Enemies[Wave_Number] == 0 && number_Of_Existed_Enemies[Wave_Number] == 0)
        {
            Set_Preparation();            
        }
    }

    public void Set_Preparation()
    {
        preparation.GetComponent<Preparation_Script>().Reset_Timer();
        Wave_Number++;
    }
}
