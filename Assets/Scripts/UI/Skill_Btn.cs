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
            Modes mode = gameObject.AddComponent<Mode_Magnit>();
            text.text = mode.GetName();
        }
        else if (rnd == 1)
        {
            Modes mode = gameObject.AddComponent<Mode_DoubleDenomination>();
            text.text = mode.GetName();
        }
        else if (rnd == 2)
        {
            Modes mode = gameObject.AddComponent<Mode_CleverLeaf>();
            text.text = mode.GetName();
        }
        else if (rnd == 3)
        {
            Modes mode = gameObject.AddComponent<Mode_MoreBits>();
            text.text = mode.GetName();
        }
        else if (rnd == 4)
        {
            Modes mode = gameObject.AddComponent<Mode_Sturdy>();
            text.text = mode.GetName();
        }
        else if (rnd == 5)
        {
            Modes mode = gameObject.AddComponent<Mode_HealthyHealth>();
            text.text = mode.GetName();
        }
        else if (rnd == 6)
        {
            Modes mode = gameObject.AddComponent<Mode_NewHorseshoes>();
            text.text = mode.GetName();
        }
        else if (rnd == 7)
        {
            Modes mode = gameObject.AddComponent<Mode_OneTimeTreatment>();
            text.text = mode.GetName();
        }
        else if (rnd == 8)
        {
            Modes mode = gameObject.AddComponent<Mode_MoreHealth>();
            text.text = mode.GetName();
        }
        else if (rnd == 9)
        {
            Modes mode = gameObject.AddComponent<Mode_TimeIsMoney>();
            text.text = mode.GetName();
        }
        else if (rnd == 10)
        {
            Modes mode = gameObject.AddComponent<Mode_IAmPower>();
            text.text = mode.GetName();
        }
        else if (rnd == 11)
        {
            Modes mode = gameObject.AddComponent<Mode_PowerPlus>();
            text.text = mode.GetName();
        }

        if ((rnd == 0 && player.mode_Magnit) || (rnd == 1 && player.mode_Double_Denomination) || (rnd == 2 && player.mode_Clover_Leaf)
            || (rnd == 3 && player.mode_MoreBits) || (rnd == 4 && player.mode_Sturdy) || (rnd == 5 && player.mode_HealthyHealth) ||
            (rnd == 6 && player.mode_NewHorseshoes) || (rnd == 7 && player.mode_OneTimeTreatment) || (rnd == 8 && player.mode_MoreHealth)
            || (rnd == 9 && player.mode_TimeIsMoney) || (rnd == 10 && player.mode_IAmPower) || (rnd == 11 && player.mode_PowerPlus))
        {
            rnd = Random.RandomRange(0, NmrOfSkills-1);
        }
    }

    public void GetSkill()
    {
        if(rnd == 0 && !player.mode_Magnit)
        {
            Modes mode = gameObject.AddComponent<Mode_Magnit>();
            ActivateMode(mode);
        }
        else if(rnd == 1 && !player.mode_Double_Denomination)
        {
            Modes mode = gameObject.AddComponent<Mode_DoubleDenomination>();
            ActivateMode(mode);
        }
        else if (rnd == 2 && !player.mode_Clover_Leaf)
        {
            Modes mode = gameObject.AddComponent<Mode_CleverLeaf>();
            ActivateMode(mode);
        }
        else if (rnd == 3 && !player.mode_MoreBits)
        {
            Modes mode = gameObject.AddComponent<Mode_MoreBits>();
            ActivateMode(mode);
        }
        else if (rnd == 4 && !player.mode_Sturdy)
        {
            Modes mode = gameObject.AddComponent<Mode_Sturdy>();
            ActivateMode(mode);
        }
        else if (rnd == 5 && !player.mode_HealthyHealth)
        {
            Modes mode = gameObject.AddComponent<Mode_HealthyHealth>();
            ActivateMode(mode);
        }
        else if (rnd == 6 && !player.mode_NewHorseshoes)
        {
            Modes mode = gameObject.AddComponent<Mode_NewHorseshoes>();
            ActivateMode(mode);
        }
        else if (rnd == 7 && !player.mode_OneTimeTreatment)
        {
            Modes mode = gameObject.AddComponent<Mode_OneTimeTreatment>();
            ActivateMode(mode);
        }
        else if (rnd == 8 && !player.mode_MoreHealth)
        {
            Modes mode = gameObject.AddComponent<Mode_MoreHealth>();
            ActivateMode(mode);
        }
        else if (rnd == 9 && !player.mode_TimeIsMoney)
        {
            Modes mode = gameObject.AddComponent<Mode_TimeIsMoney>();
            ActivateMode(mode);
        }
        else if (rnd == 10 && !player.mode_IAmPower)
        {
            Modes mode = gameObject.AddComponent<Mode_IAmPower>();
            ActivateMode(mode);
        }
        else if (rnd == 11 && !player.mode_PowerPlus)
        {
            Modes mode = gameObject.AddComponent<Mode_PowerPlus>();
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
