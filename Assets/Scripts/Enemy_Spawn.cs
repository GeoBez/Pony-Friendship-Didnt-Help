using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public Enemy enemy;
    public float time;
    float default_Time;

    void Start()
    {
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
            Instantiate(enemy, transform.position, transform.rotation);
            time = default_Time;
        }
    }
}
