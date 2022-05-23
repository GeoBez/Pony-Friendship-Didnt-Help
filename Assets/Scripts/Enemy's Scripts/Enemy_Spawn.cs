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
    Wave_System wave_System;

    private int _enemy_Count;

    void Start()
    {
        preparation = GameObject.FindGameObjectWithTag("Preparation").GetComponent<Preparation_Script>();
        wave_System = GameObject.FindGameObjectWithTag("Wave System").GetComponent<Wave_System>();
        default_Time = time;
        if (enemy.tag == "Tower_Enemy")
        {
            enemy.GetComponent<FollowPath>().MyPath = gameObject.GetComponentInChildren<MovementPath>();
        }
    }

    /*void Update()
    {
        inPreparation = preparation.inPreparation;
        if (!inPreparation)
        {
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
                    wave_System.number_Of_Enemies[wave_Number]--;
                }
                time = default_Time;
            }
        }
    }*/

    public void SpawnEnemy(GameObject enemy, int enemy_Count)
    {        
        this.enemy = enemy;
        _enemy_Count = enemy_Count;

        if (enemy.tag == "Tower_Enemy")
        {
            enemy.GetComponent<FollowPath>().MyPath = gameObject.GetComponentInChildren<MovementPath>();
        }

        StartCoroutine(CreateEnemyFor2Seconds());
        StopCoroutine(CreateEnemyFor2Seconds());
    }
       
    private IEnumerator CreateEnemyFor2Seconds()
    {
        for (int i = 0; i < _enemy_Count; i++)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            yield return new WaitForSeconds(2);
        }        
    }
}
