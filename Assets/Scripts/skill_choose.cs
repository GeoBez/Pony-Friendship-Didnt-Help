using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill_choose : MonoBehaviour
{
    List<Modes> _allModes;
    public ButtonCard[] cards;

    void Start()
    {
        _allModes = new List<Modes>() {gameObject.AddComponent<Mode_Magnit>(),
            gameObject.AddComponent<Mode_DoubleDenomination>(),
            gameObject.AddComponent<Mode_CleverLeaf>(),
            gameObject.AddComponent<Mode_MoreBits>(),
            gameObject.AddComponent<Mode_Sturdy>(),
            gameObject.AddComponent<Mode_HealthyHealth>(),
            gameObject.AddComponent<Mode_NewHorseshoes>(),
            gameObject.AddComponent<Mode_OneTimeTreatment>(),
            gameObject.AddComponent<Mode_MoreHealth>(),
            gameObject.AddComponent<Mode_TimeIsMoney>(),
            gameObject.AddComponent<Mode_IAmPower>(),
            gameObject.AddComponent<Mode_PowerPlus>(),
            gameObject.AddComponent<Mode_SimpleDistanteBattle>(),
            gameObject.AddComponent<Mode_SittingUpper>(),
            gameObject.AddComponent<Mode_IAmSpeed>(),
            gameObject.AddComponent<Mode_YouShallNoPass>()};

        foreach(var mode in _allModes)
        {
            if (mode.isUsed)
                mode.Activate();
        }
    }

    public void MakeCard()
    {
        foreach (var card in cards){
            var mod = GenerateCard();

            card.descriptionText.text = mod.GetDescription();
            card.nameText.text = mod.GetName();
            //card.image = mod.GetImage();
            Debug.Log(card.nameText);
        }
    } 

    Modes GenerateCard()
    {
        int cout = Random.Range(0, _allModes.Count-1);

        while (!_allModes[cout].isUsed)
        {
            cout = Random.Range(0, _allModes.Count - 1);
        }
        return _allModes[cout];
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
