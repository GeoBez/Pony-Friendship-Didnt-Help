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

    internal void Initialize(Tower tower)
    {
        //nameText.text = tower.name;
        //descriptoinText.text = "описание" + tower.name;
        towerCost.text = tower.price.ToString();
        coolDown.text = tower.GetComponentInChildren<Weapon>().projectile.coolDown.ToString();
        damage.text = tower.Damage.ToString();
    }
}
