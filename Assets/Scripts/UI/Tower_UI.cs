using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_UI : MonoBehaviour
{
     public Tower Tower;

    public Description description;
    public void CreateTower()
    {
            if (!description.gameObject.activeInHierarchy)
            {
                description.gameObject.SetActive(true);
                description.Initialize(Tower);
                return;
            }
        PlayerStatistics.BuyPurchase(Tower);
        description.gameObject.SetActive(false);
    }
}
