using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_choose : MonoBehaviour
{
    [SerializeField] private Text _Name;
    public Text Name => _Name;
    [SerializeField] private Text _Description;
    public Text Description => _Description;
    [SerializeField] private Image _Image;
    public Image Image => _Image;

    public TypeUpgrade typeUpgrade { get; private set; }

    public void DefaultTypeUpgrade()
    {
        typeUpgrade = 0;
    }
    public void SetButton(ButtonCard buttonCard)
    {
        Image.sprite = buttonCard.Avatar;
        Name.text = buttonCard.Name;
        Description.text = buttonCard.Description;
        typeUpgrade = buttonCard.typeUpgrade;
    }
    /// <summary>
    /// Навешан через Инспектор в UpgradeChoiceMenu->GroupButtons->Button [Number] - 1, 2, 3
    /// </summary>
    public void OnButton()
    {
        GenerateCardUpgrade.UsedUpgrade(typeUpgrade);
        UpgradeChoiceMenu.instance.MenuClosed();
    }
}
