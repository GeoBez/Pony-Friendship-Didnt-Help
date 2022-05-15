using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Btn : MonoBehaviour
{
    public static int rnd;
    public int NmrOfSkills;
    public Skill_Canvas canvas;
    Player player;
    Text text;

    private void Start()
    {
        canvas = GetComponentInParent<Skill_Canvas>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rnd = Random.RandomRange(0, NmrOfSkills - 1);
        text = GetComponentInChildren<Text>();
        GetSkill();
    }

    //private void Update()
    //{
    //    Modes mode = new Mode_Magnit();
    //    text.text = mode.GetName();
    //}

    public void GetSkill()
    {
        if(rnd == 0 && !player.mode_Magnit)
        {
            player.mode_Magnit = true;
            Modes mode = new Mode_Magnit();
        }
        else if(rnd == 1 && !player.mode_Double_Denomination)
        {
            player.mode_Double_Denomination = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 2 && !player.mode_Clover_Leaf)
        {
            player.mode_Clover_Leaf = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 3 && !player.mode_MoreBits)
        {
            player.mode_MoreBits = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 4 && !player.mode_Sturdy)
        {
            player.mode_Sturdy = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 5 && !player.mode_HealthyHealth)
        {
            player.mode_HealthyHealth = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 6 && !player.mode_NewHorseshoes)
        {
            player.mode_NewHorseshoes = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 7 && !player.mode_OneTimeTreatment)
        {
            player.mode_OneTimeTreatment = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 8 && !player.mode_MoreHealth)
        {
            player.mode_MoreHealth = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 9 && !player.mode_TimeIsMoney)
        {
            player.mode_TimeIsMoney = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 10 && !player.mode_IAmPower)
        {
            player.mode_IAmPower = true;
            Modes mode = new Mode_Magnit();
        }
        else if (rnd == 11 && !player.mode_PowerPlus)
        {
            player.mode_PowerPlus = true;
            Modes mode = new Mode_Magnit();
        }
        else
        {
            rnd = Random.RandomRange(0, NmrOfSkills);
        }
    }

    void ActivateMode(Modes mode)
    {
        rnd = Random.RandomRange(0, NmrOfSkills);
        text.text = mode.GetName();
        canvas.skill_Points--;
        mode.Activate();
    }
}
