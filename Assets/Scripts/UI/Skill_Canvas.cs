using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Canvas : MonoBehaviour
{
    XP_Bar xp_Bar;
    public int skill_Points;
    [SerializeField] private GameObject skillsGroup;

    private void Start()
    {
        xp_Bar = GameObject.Find("XP_Bar").GetComponent<XP_Bar>();
        skill_Points = 0;
    }

    void Update()
    {
        if(skill_Points <= 0)
        {
            Time.timeScale = 1;
            xp_Bar.skill_Points = 0;
            skillsGroup.SetActive(false);
        }
    }
}
