using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    public Text nameText;
    public Text descriptoinText;
    public Text towerCost;
    public Text coolDown;
    public Text damage;

    internal void Initialize(IPurchased purchase)
    {
        nameText.text = purchase.Name;
        towerCost.text = purchase.Priñe.ToString();
        descriptoinText.text = purchase.Description;
        Text[] texts = new Text[] { towerCost, coolDown, damage };
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = purchase.Specifications[i];
        }
    }
}
