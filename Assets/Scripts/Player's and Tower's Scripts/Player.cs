using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;
    public GameObject GameOverMenu;

    private void Start()
    {
        GetComponent<PlayerMovement>().speed = speed;
        GameOverMenu = GameObject.FindGameObjectWithTag("GameOver");
        GameOverMenu.SetActive(false);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameOverMenu.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
