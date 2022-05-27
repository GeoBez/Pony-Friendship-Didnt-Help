using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill_choose : MonoBehaviour
{
    public List<Modes> _allModes = new List<Modes>();
    public ButtonCard[] cards;
    public GameObject skills_Canvas;
    public XP_Bar xp_Bar;

    private bool isStartWas = false;
    public bool _isItWork = false;

    void Start()
    {
        _allModes = new List<Modes>() {new Mode_Magnit(),
            new Mode_DoubleDenomination(),
            new Mode_CleverLeaf(),
            new Mode_MoreBits(),
            new Mode_Sturdy(),
            new Mode_HealthyHealth(),
            new Mode_NewHorseshoes(),
            new Mode_OneTimeTreatment(),
            new Mode_MoreHealth(),
            new Mode_TimeIsMoney(),
            new Mode_IAmPower(),
            new Mode_PowerPlus(),
            new Mode_SimpleDistanteBattle(),
            new Mode_SittingUpper(),
            new Mode_IAmSpeed(),
            new Mode_YouShallNoPass()};

        foreach(var mode in _allModes)
        {
            if (mode.isUsed)
                mode.Activate();
        }
    }

    public void MakeCard()
    {        
        if (!isStartWas)
        {
            isStartWas = true;
            Start();
        }

        if (!_isItWork)
        {
            _isItWork = true;
            foreach (var card in cards)
            {
                Modes mod;
                var count =  GenerateIndex();
                if (count != -1)
                    mod = _allModes[count];
                else
                    mod = new Mode_Extra();//gameObject.AddComponent<Mode_Extra>();

                card.descriptionText.text = mod.GetDescription();
                card.nameText.text = mod.GetName();

                var Cardbutton = card.button.GetComponent<button_choose>();
                Cardbutton.mod = mod;
                Cardbutton.index = count;

                //card.image = mod.GetImage();
            }
        }
    } 

    int GenerateIndex()
    {
        int cout;
        if (_allModes.Count > 4)
        {
            cout = Random.Range(0, _allModes.Count - 1);

            while (_allModes[cout].isUsed)
            {
                cout = Random.Range(0, _allModes.Count - 1);
            }

            _allModes[cout].isUsed = true;
        }
        else
        {
            Debug.Log("Улучшения кончились!!");
            cout = -1;
        }
        return cout;
    }
}

[System.Serializable]
public class ButtonCard
{
    public GameObject button;

    public Image image;
    public Text nameText;
    public Text descriptionText;
}
