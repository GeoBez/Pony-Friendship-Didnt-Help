using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    /*Button CTB; //Create Tower Button

    public GameObject Tower;
    GameObject Player;

    private Tower tower;
    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CTB = GameObject.FindGameObjectWithTag("CTB").GetComponent<Button>();
    }

    public void Update()
    {
        if (Player != null)
        {
            if (Player.GetComponent<Player>().inTowerCollider)
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
        var tower = Tower.GetComponent<Tower>();
        if (PlayerStatistic.Coins >= tower.price)
        {
            Debug.Log("LAter");
            PlayerStatistic.Buy(tower.price);
            Instantiate(Tower, Player.transform.position, Quaternion.identity);
        }
    }*/
}
