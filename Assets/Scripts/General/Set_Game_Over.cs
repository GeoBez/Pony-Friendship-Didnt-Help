using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_Game_Over : MonoBehaviour
{
    public Player PHealth;
    public Tower MTHealth;
    public GameObject GameOverMenu;


    private void Start()
    {
        PHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        MTHealth = GameObject.FindGameObjectWithTag("Main Tower").GetComponent<Tower>();
        //GameOverMenu = GameObject.FindGameObjectWithTag("GameOver");
        GameOverMenu.SetActive(false);
    }

    private void Update()
    {
        if (PHealth != null)
            if (PHealth.Health <= 0)
            {
                Destroy(PHealth.gameObject);
                GameOverMenu.SetActive(true);
            }

        if (MTHealth != null)
            if (MTHealth.health <= 0)
            {
                Destroy(MTHealth.gameObject);
                GameOverMenu.SetActive(true);
            }
    }
}

      
