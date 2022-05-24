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
    public XP_Bar xp_Bar;
    public Text nameText;
    public Text descriptionText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rnd = Random.Range(0, NmrOfSkills - 1);
        GetSkill();
    }

    private void Update()
    {
        if (rnd == 0)
        {
            Modes mode = gameObject.AddComponent<Mode_Magnit>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 1)
        {
            Modes mode = gameObject.AddComponent<Mode_DoubleDenomination>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 2)
        {
            Modes mode = gameObject.AddComponent<Mode_CleverLeaf>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 3)
        {
            Modes mode = gameObject.AddComponent<Mode_MoreBits>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 4)
        {
            Modes mode = gameObject.AddComponent<Mode_Sturdy>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 5)
        {
            Modes mode = gameObject.AddComponent<Mode_HealthyHealth>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 6)
        {
            Modes mode = gameObject.AddComponent<Mode_NewHorseshoes>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 7)
        {
            Modes mode = gameObject.AddComponent<Mode_OneTimeTreatment>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 8)
        {
            Modes mode = gameObject.AddComponent<Mode_MoreHealth>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 9)
        {
            Modes mode = gameObject.AddComponent<Mode_TimeIsMoney>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 10)
        {
            Modes mode = gameObject.AddComponent<Mode_IAmPower>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }
        else if (rnd == 11)
        {
            Modes mode = gameObject.AddComponent<Mode_PowerPlus>();
            nameText.text = mode.GetName();
            descriptionText.text = mode.GetDescription();
        }

        if ((rnd == 0 && player.mode_Magnit) || (rnd == 1 && player.mode_Double_Denomination) || (rnd == 2 && player.mode_Clover_Leaf)
            || (rnd == 3 && player.mode_MoreBits) || (rnd == 4 && player.mode_Sturdy) || (rnd == 5 && player.mode_HealthyHealth) ||
            (rnd == 6 && player.mode_NewHorseshoes) || (rnd == 7 && player.mode_OneTimeTreatment) || (rnd == 8 && player.mode_MoreHealth)
            || (rnd == 9 && player.mode_TimeIsMoney) || (rnd == 10 && player.mode_IAmPower) || (rnd == 11 && player.mode_PowerPlus))
        {
            rnd = Random.Range(0, NmrOfSkills - 1);
        }
    }

    public void GetSkill()
    {
        if (rnd == 0 && !player.mode_Magnit)
        {
            
            player.mode_Magnit = true;
            Modes mode = gameObject.AddComponent<Mode_Magnit>();
            ActivateMode(mode);
        }
        else if(rnd == 1 && !player.mode_Double_Denomination)
        {
            player.mode_Double_Denomination = true;
            Modes mode = gameObject.AddComponent<Mode_DoubleDenomination>();
            ActivateMode(mode);
        }
        else if (rnd == 2 && !player.mode_Clover_Leaf)
        {
            player.mode_Clover_Leaf = true;
            Modes mode = gameObject.AddComponent<Mode_CleverLeaf>();
            ActivateMode(mode);
        }
        else if (rnd == 3 && !player.mode_MoreBits)
        {
            player.mode_MoreBits = true;
            Modes mode = gameObject.AddComponent<Mode_MoreBits>();
            ActivateMode(mode);
        }
        else if (rnd == 4 && !player.mode_Sturdy)
        {
            player.mode_Sturdy = true;
            Modes mode = gameObject.AddComponent<Mode_Sturdy>();
            ActivateMode(mode);
        }
        else if (rnd == 5 && !player.mode_HealthyHealth)
        {
            player.mode_HealthyHealth = true;
            Modes mode = gameObject.AddComponent<Mode_HealthyHealth>();
            ActivateMode(mode);
        }
        else if (rnd == 6 && !player.mode_NewHorseshoes)
        {
            player.mode_NewHorseshoes = true;
            Modes mode = gameObject.AddComponent<Mode_NewHorseshoes>();
            ActivateMode(mode);
        }
        else if (rnd == 7 && !player.mode_OneTimeTreatment)
        {
            player.mode_OneTimeTreatment = true;
            Modes mode = gameObject.AddComponent<Mode_OneTimeTreatment>();
            ActivateMode(mode);
        }
        else if (rnd == 8 && !player.mode_MoreHealth)
        {
            player.mode_MoreHealth = true;
            Modes mode = gameObject.AddComponent<Mode_MoreHealth>();
            ActivateMode(mode);
        }
        else if (rnd == 9 && !player.mode_TimeIsMoney)
        {
            player.mode_TimeIsMoney = true;
            Modes mode = gameObject.AddComponent<Mode_TimeIsMoney>();
            ActivateMode(mode);
        }
        else if (rnd == 10 && !player.mode_IAmPower)
        {
            player.mode_IAmPower = true;
            Modes mode = gameObject.AddComponent<Mode_IAmPower>();
            ActivateMode(mode);
        }
        else if (rnd == 11 && !player.mode_PowerPlus)
        {
            player.mode_PowerPlus = true;
            Modes mode = gameObject.AddComponent<Mode_PowerPlus>();
            ActivateMode(mode);
        }
    }

    void ActivateMode(Modes mode)
    {
        rnd = Random.Range(0, NmrOfSkills - 1);
        canvas.skill_Points--;
        xp_Bar.skill_Points--;
        mode.Activate();
    }
}
