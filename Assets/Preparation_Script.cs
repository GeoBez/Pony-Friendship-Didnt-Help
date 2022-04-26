using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preparation_Script : MonoBehaviour
{
    public float timer;
    float default_time;
    public bool inPreparation;

    private void Start()
    {
        default_time = timer;
        inPreparation = true;
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            inPreparation = false;
        }
    }

    public void End_Time()
    {
        timer = -1;
    }

    public void Reset_Timer()
    {
        inPreparation = true;
        timer = default_time;
    }
}