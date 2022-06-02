using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP_Bar : MonoBehaviour
{
    int xp;
    public int Max_XP;
    int Past_Max_XP;
    public int skill_Points;
    public int level;
    Slider fill_Value;
    Preparation_Script preparation;

    public GameObject skills_Canvas;

    void Start()
    {
        Past_Max_XP = 5;
        level = 1;
        Max_XP = 5;
        fill_Value = GetComponent<Slider>();
        fill_Value.value = 0;
        fill_Value.maxValue = Max_XP;
        skills_Canvas.SetActive(false);
        preparation = GameObject.FindGameObjectWithTag("Preparation").GetComponent<Preparation_Script>();
        xp = 0;
    }

    public void TranslateSkillPoints()
    {
        if (skill_Points > 0 && preparation.inPreparation)
            SetSkillCanvas();
    }

    public void Update_Bar(int xp_points)
    {
        xp += xp_points;
        fill_Value.value = xp;
        //Debug.Log(xp + " "+ level);

        if(xp>=Max_XP)
        {
            skill_Points++;
            level++;
            int Rest_Of_XP = xp - Max_XP;
            xp = 0;
            xp += Rest_Of_XP;
            if (level < 7)
            {
                Max_XP += Past_Max_XP;
                Past_Max_XP = Max_XP;
                fill_Value.maxValue = Max_XP;
            }
            else if (level > 6)
            {
                Max_XP = Max_XP * 2;
                fill_Value.maxValue = Max_XP;
            }
        }

        //if (skill_Points > 0 && preparation.inPreparation)
        //    SetSkillCanvas();
    }

    public void SetSkillCanvas()
    {
        skills_Canvas.SetActive(true);
        skills_Canvas.GetComponentInChildren<skill_choose>().MakeCard();
        skills_Canvas.GetComponentInChildren<Skill_Canvas>().skill_Points = skill_Points;
        Time.timeScale = 0;
        fill_Value.value = xp;
    }
}
