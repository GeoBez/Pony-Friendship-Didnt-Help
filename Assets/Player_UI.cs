using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    public Button CTB; //Create Tower Button

    public GameObject Tower;
    public GameObject Player;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CTB = GameObject.FindGameObjectWithTag("CTB").GetComponent<Button>();
    }

    public void Update()
    {
        if(Player.GetComponent<Player>().inTowerCollider)
        {
            CTB.interactable = false;
        }
        else
        {
            CTB.interactable = true;
        }
    }

    public void CreateTower()
    {
        Instantiate(Tower, Player.transform.position, Quaternion.identity);
    }
}
