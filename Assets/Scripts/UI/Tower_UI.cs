using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_UI : MonoBehaviour
{
    Button CTB; //Create Tower Button
    Text cost;

    public GameObject Tower;
    GameObject Player;

    public Description description;

    private Tower tower;
    public void Start()
    {
        tower = Tower.GetComponent<Tower>();
        Player = GameObject.FindGameObjectWithTag("MainPlayer");
        CTB = GameObject.FindGameObjectWithTag("CTB").GetComponent<Button>();
        cost = CTB.GetComponentInChildren<Text>();
        cost.text = tower.price.ToString();
    }

    public void Update()
    {
        if (Player != null)
        {
            if (Player.GetComponentInChildren<Player>().inTowerCollider)
            {
                CTB.interactable = false;
            }
            else
            {
                CTB.interactable = true;
            }
        }
    }
    public void CreateTower()
    {
        if (Coin_Count_Text.coin_Count >= tower.price)
        {
            if (!description.gameObject.activeInHierarchy)
            {
                description.gameObject.SetActive(true);
                description.Initialize(tower);
                return;
            }
            Coin_Count_Text.coin_Count -= tower.price;
            Instantiate(Tower, Player.transform.position, Quaternion.identity);
            description.gameObject.SetActive(false);
        }
    }
}
