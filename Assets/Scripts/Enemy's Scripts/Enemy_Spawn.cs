using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject enemy;
    public float time;

    Preparation preparation;
    float default_Time;
    private int _enemy_Count;

    void Start()
    {
        preparation = GameObject.FindGameObjectWithTag("Preparation").GetComponent<Preparation>();
        default_Time = time;
        if (enemy.tag == "Tower_Enemy")
        {
            enemy.GetComponent<FollowPath>().MyPath = gameObject.GetComponentInChildren<MovementPath>();
        }
    }

    public void SpawnEnemy(GameObject enemy, int enemy_Count)
    {        
        this.enemy = enemy;
        _enemy_Count = enemy_Count;

        StartCoroutine(CreateEnemyFor2Seconds());
    }
       
    private IEnumerator CreateEnemyFor2Seconds()
    {
        for (int i = 0; i < _enemy_Count; i++)
        {
            if (enemy.tag == "Tower_Enemy")
            {
                enemy.GetComponent<FollowPath>().MyPath = gameObject.GetComponentInChildren<MovementPath>();
            }
            Enemy.AddEnemy(enemy, transform);
            yield return new WaitForSeconds(2);
        }
        yield break;
    }
}
