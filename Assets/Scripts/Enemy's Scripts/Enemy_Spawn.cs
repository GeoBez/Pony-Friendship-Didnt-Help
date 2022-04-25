using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject enemy;
    public float time;
    float default_Time;
    Wave_System wave_Number_Enemies;

    void Start()
    {
        wave_Number_Enemies = GameObject.FindGameObjectWithTag("Wave System").GetComponent<Wave_System>();
        default_Time = time;
    }

    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else if (time < 0)
        {
            for (int i = 0; i < wave_Number_Enemies.number_Of_Enemies.Length; i++)
            {
                wave_Number_Enemies.number_Of_Enemies[i]--;
            }
            Instantiate(enemy, transform.position, transform.rotation);
            time = default_Time;
        }

        if(enemy.tag == "Tower_Enemy")
        {
            enemy.GetComponent<FollowPath>().MyPath = gameObject.GetComponentInChildren<MovementPath>();
        }
    }
}
