using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preparation_Script : MonoBehaviour
{
    public float timer;
    float default_time;
    public bool inPreparation;

    int minutes;
    string seconds;

    Text text;
    Button button;

    private void Start()
    {
        default_time = timer;
        inPreparation = true;
        text = GetComponentInChildren<Text>();
        button = GetComponentInChildren<Button>();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer <= 0)
        {
            inPreparation = false;
        }

        minutes = (int)timer / 60;
        if (((int)timer % 60) < 10)
        {
            seconds = "0" + ((int)timer % 60).ToString();
        }
        else
        {
            seconds = ((int)timer % 60).ToString();
        }
        text.text = minutes + ":" + seconds;

        if(!inPreparation)
        {
            text.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
        }
        else
        {
            text.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
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