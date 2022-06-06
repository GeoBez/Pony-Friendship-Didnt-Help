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

    private int _enemy_Count;

    bool isSpawning;

    void Start()
    {
        preparation = GameObject.FindGameObjectWithTag("Preparation").GetComponent<Preparation_Script>();
        default_Time = time;
        if (enemy.tag == "Tower_Enemy")
        {
            enemy.GetComponent<FollowPath>().MyPath = gameObject.GetComponentInChildren<MovementPath>();
        }
    }

    void Update()
    {
        //inPreparation = preparation.inPreparation;
        //if (!inPreparation)
        //{
        //    if (time >= 0)
        //    {
        //        time -= Time.deltaTime;
        //    }
        //    else if (time < 0)
        //    {
        //        int wave_Number = wave_System.Wave_Number;
        //        if (wave_System.number_Of_Enemies[wave_Number] > 0)
        //        {
        //            Instantiate(enemy, transform.position, transform.rotation);
        //            wave_System.number_Of_Enemies[wave_Number]--;
        //        }
        //        time = default_Time;
        //    }
        //}

        if (isSpawning)
        {
            if (enemy.tag == "Tower_Enemy")
            {
                enemy.GetComponent<FollowPath>().MyPath = gameObject.GetComponentInChildren<MovementPath>();
            }
            StartCoroutine(CreateEnemyFor2Seconds());
            StopCoroutine(CreateEnemyFor2Seconds());
        }
    }

    public void SpawnEnemy(GameObject enemy, int enemy_Count)
    {        
        this.enemy = enemy;
        _enemy_Count = enemy_Count;

        isSpawning = true;
    }
       
    private IEnumerator CreateEnemyFor2Seconds()
    {
        for (int i = 0; i < _enemy_Count; i++)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            isSpawning = false;
            yield return new WaitForSeconds(2);
        }        
    }
}
