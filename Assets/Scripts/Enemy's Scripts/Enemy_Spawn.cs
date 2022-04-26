using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject enemy;
    public float time;

    Preparation_Script preparation;
    bool inPreparation;
    float default_Time;
<<<<<<< Updated upstream
    Wave_System wave_Number_Enemies;

    void Start()
    {
        wave_Number_Enemies = GameObject.FindGameObjectWithTag("Wave System").GetComponent<Wave_System>();
=======
    Wave_System wave_System;

    void Start()
    {
        preparation = GameObject.FindGameObjectWithTag("Preparation").GetComponent<Preparation_Script>();
        wave_System = GameObject.FindGameObjectWithTag("Wave System").GetComponent<Wave_System>();
>>>>>>> Stashed changes
        default_Time = time;
    }

    void Update()
    {
        inPreparation = preparation.inPreparation;
        if (!inPreparation)
        {
<<<<<<< Updated upstream
            for (int i = 0; i < wave_Number_Enemies.number_Of_Enemies.Length; i++)
            {
                wave_Number_Enemies.number_Of_Enemies[i]--;
            }
            Instantiate(enemy, transform.position, transform.rotation);
            time = default_Time;
=======
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            else if (time < 0)
            {
                int wave_Number = wave_System.Wave_Number;
                if (wave_System.number_Of_Enemies[wave_Number] > 0)
                {
                    Instantiate(enemy, transform.position, transform.rotation);
                    wave_System.Reduce_NoE();
                    wave_System.number_Of_Enemies[wave_Number]--;
                }
                time = default_Time;
            }
>>>>>>> Stashed changes
        }

        if(enemy.tag == "Tower_Enemy")
        {
            enemy.GetComponent<FollowPath>().MyPath = gameObject.GetComponentInChildren<MovementPath>();
        }
    }
}
