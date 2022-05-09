using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_System : MonoBehaviour
{
    public int Wave_Number;
    public int[] number_Of_Enemies;
    public GameObject preparation;

    private void Start()
    {
        preparation = GameObject.FindGameObjectWithTag("Preparation");
        Wave_Number = 0;
    }

    public void Rise_Wave_Number()
    {
        if (Wave_Number == number_Of_Enemies.Length)
                gameObject.SetActive(false);
        else if (number_Of_Enemies[Wave_Number] == 0)
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
