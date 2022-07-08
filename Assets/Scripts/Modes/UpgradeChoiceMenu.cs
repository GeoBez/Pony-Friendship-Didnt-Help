using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeChoiceMenu : MonoBehaviour
{
    [SerializeField] private button_choose[] Buttons;
    public button_choose[] Button_Chooses => Buttons;
    public static UpgradeChoiceMenu instance { get; private set; }
    private void Start()
    {
        instance = this;
    }
    /// <summary>
    ///При открытии меню, выбираются карточки умений
    ///Добавлять или менять что либо нельзя!
    ///</summary>
    private void OnEnable()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            ButtonCard card;
            do
            {
                card = GenerateCardUpgrade.GetCardRandom();
                if (GenerateCardUpgrade.CountTypeUpgrade < i + 1)
                    card = GenerateCardUpgrade.GetCardAt(TypeUpgrade.None);
            }
            while (card.typeUpgrade != TypeUpgrade.None &&
            Buttons.Where(Butt => Butt.typeUpgrade == card.typeUpgrade).Count() > 0);
            Buttons[i].SetButton(card);
        }
    }
    private void OnDisable()
    {
        foreach (button_choose choice in Buttons)
            choice.DefaultTypeUpgrade();

    }
    public void MenuClosed()
    {
        Menu.SetPause(false);
        gameObject.SetActive(false);
        MenuOpen();
    }
    public void MenuOpen()
    {
        if (PlayerStatistic.Level > PlayerStatistic.ReceivedСards)
        {
            Menu.SetPause(true);
            gameObject.SetActive(true);
        }
    }
}
