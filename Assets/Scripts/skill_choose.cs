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

    private skill_choose parent;
    private Skill_Canvas skill_canvas;


    private bool isStartWas = false;
    public bool _isItWork = false;

    private YandexSDK yandexSDK;

    void Start()
    {

        parent = GetComponentInParent<skill_choose>();
        skill_canvas = GetComponentInParent<Skill_Canvas>();

        _allModes = new List<Modes>() {
            gameObject.AddComponent<Mode_Magnit>(),
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
            gameObject.AddComponent<Mode_IAmSpeed>()};

        //тут надо как-то сделать активацию начальных скилов (перенести из старта )
        foreach(var mode in _allModes)
        {
            if (mode.isUsed)
                mode.Activate();
        }
        _isItWork = false;

        yandexSDK = YandexSDK.instance;
        yandexSDK.onRewardedAdReward += Reward;
    }

    private void Reward(string placement)
    {
        if (placement == "ReMakeCard")
        {
            ReMakeCard();
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

            ReMakeCard();
        }
    }

    public void ReMakeCard()
    {
        foreach (var card in cards)
        {
            Modes mod;
            var count = GenerateIndex();

            if (count != -1)
                mod = _allModes[count];
            else
                mod = gameObject.AddComponent<Mode_Extra>();

            try
            {
                if (mod.GetName() == null || mod.GetDescription() == null)
                {
                    count = -1;
                    mod = gameObject.AddComponent<Mode_Extra>();
                    //card.button.GetComponent<button_choose>().MakeMoodActive();

                    //mod.Activate();
                    //skill_canvas.skill_Points--;
                    //parent.xp_Bar.skill_Points--;
                    //_isItWork = false;

                    throw new System.Exception("Mods name or description is null!");
                }
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }
            finally
            {
                card.descriptionText.text = mod.GetDescription();
                card.nameText.text = mod.GetName();
                card.image.sprite = mod.GetImage();

                var Cardbutton = card.button.GetComponent<button_choose>();
                Cardbutton.mod = mod;
                Cardbutton.index = count;
            }
        }
    }

    public void MakeNotActive()
    {
        foreach (var y in _allModes)
            y.isUsed = false;
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
            Debug.Log("”лучшени€ кончились!!");
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
