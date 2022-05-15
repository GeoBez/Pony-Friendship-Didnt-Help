using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Btn : MonoBehaviour
{
    public int rnd;
    public int NmrOfSkills;
    public Skill_Canvas canvas;
    Player player;
    Text text;
    public XP_Bar xp_Bar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rnd = Random.RandomRange(0, NmrOfSkills - 1);
        text = GetComponentInChildren<Text>();
        GetSkill();
    }

    private void Update()
    {
        if (rnd == 0)
        {
            Modes mode = new Mode_Magnit();
            text.text = mode.GetName();
        }
        else if (rnd == 1)
        {
            Modes mode = new Mode_DoubleDenomination();
            text.text = mode.GetName();
        }
        else if (rnd == 2)
        {
            Modes mode = new Mode_CleverLeaf();
            text.text = mode.GetName();
        }
        else if (rnd == 3)
        {
            Modes mode = new Mode_MoreBits();
            text.text = mode.GetName();
        }
        else if (rnd == 4)
        {
            Modes mode = new Mode_Sturdy();
            text.text = mode.GetName();
        }
        else if (rnd == 5)
        {
            Modes mode = new Mode_HealthyHealth();
            text.text = mode.GetName();
        }
        else if (rnd == 6)
        {
            Modes mode = new Mode_NewHorseshoes();
            text.text = mode.GetName();
        }
        else if (rnd == 7)
        {
            Modes mode = new Mode_OneTimeTreatment();
            text.text = mode.GetName();
        }
        else if (rnd == 8)
        {
            Modes mode = new Mode_MoreHealth();
            text.text = mode.GetName();
        }
        else if (rnd == 9)
        {
            Modes mode = new Mode_TimeIsMoney();
            text.text = mode.GetName();
        }
        else if (rnd == 10)
        {
            Modes mode = new Mode_IAmPower();
            text.text = mode.GetName();
        }
        else if (rnd == 11)
        {
            Modes mode = new Mode_PowerPlus();
            text.text = mode.GetName();
        }

        if ((rnd == 0 && player.mode_Magnit) || (rnd == 1 && player.mode_Double_Denomination) || (rnd == 2 && player.mode_Clover_Leaf)
            || (rnd == 3 && player.mode_MoreBits) || (rnd == 4 && player.mode_Sturdy) || (rnd == 5 && player.mode_HealthyHealth) ||
            (rnd == 6 && player.mode_NewHorseshoes) || (rnd == 7 && player.mode_OneTimeTreatment) || (rnd == 8 && player.mode_MoreHealth)
            || (rnd == 9 && player.mode_TimeIsMoney) || (rnd == 10 && player.mode_IAmPower) || (rnd == 11 && player.mode_PowerPlus))
        {
            rnd = Random.RandomRange(0, NmrOfSkills);
        }
    }

    public void GetSkill()
    {
        if(rnd == 0 && !player.mode_Magnit)
        {
            player.mode_Magnit = true;
            Modes mode = new Mode_Magnit();
            ActivateMode(mode);
        }
        else if(rnd == 1 && !player.mode_Double_Denomination)
        {
            player.mode_Double_Denomination = true;
            Modes mode = new Mode_DoubleDenomination();
            ActivateMode(mode);
        }
        else if (rnd == 2 && !player.mode_Clover_Leaf)
        {
            player.mode_Clover_Leaf = true;
            Modes mode = new Mode_CleverLeaf();
            ActivateMode(mode);
        }
        else if (rnd == 3 && !player.mode_MoreBits)
        {
            player.mode_MoreBits = true;
            Modes mode = new Mode_MoreBits();
            ActivateMode(mode);
        }
        else if (rnd == 4 && !player.mode_Sturdy)
        {
            player.mode_Sturdy = true;
            Modes mode = new Mode_Sturdy();
            ActivateMode(mode);
        }
        else if (rnd == 5 && !player.mode_HealthyHealth)
        {
            player.mode_HealthyHealth = true;
            Modes mode = new Mode_HealthyHealth();
            ActivateMode(mode);
        }
        else if (rnd == 6 && !player.mode_NewHorseshoes)
        {
            player.mode_NewHorseshoes = true;
            Modes mode = new Mode_NewHorseshoes();
            ActivateMode(mode);
        }
        else if (rnd == 7 && !player.mode_OneTimeTreatment)
        {
            player.mode_OneTimeTreatment = true;
            Modes mode = new Mode_OneTimeTreatment();
            ActivateMode(mode);
        }
        else if (rnd == 8 && !player.mode_MoreHealth)
        {
            player.mode_MoreHealth = true;
            Modes mode = new Mode_MoreHealth();
            ActivateMode(mode);
        }
        else if (rnd == 9 && !player.mode_TimeIsMoney)
        {
            player.mode_TimeIsMoney = true;
            Modes mode = new Mode_TimeIsMoney();
            ActivateMode(mode);
        }
        else if (rnd == 10 && !player.mode_IAmPower)
        {
            player.mode_IAmPower = true;
            Modes mode = new Mode_IAmPower();
            ActivateMode(mode);
        }
        else if (rnd == 11 && !player.mode_PowerPlus)
        {
            player.mode_PowerPlus = true;
            Modes mode = new Mode_PowerPlus();
            ActivateMode(mode);
        }
    }

    void ActivateMode(Modes mode)
    {
        rnd = Random.RandomRange(0, NmrOfSkills);
        canvas.skill_Points--;
        xp_Bar.skill_Points--;
        mode.Activate();
    }
}
