using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Btn : MonoBehaviour
{
    Skill_Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Skill_Canvas>();
    }

    public void Back_Time()
    {
        if (canvas.skill_Points == 0)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
        else
        {
            canvas.skill_Points--;
        }
    }
}
