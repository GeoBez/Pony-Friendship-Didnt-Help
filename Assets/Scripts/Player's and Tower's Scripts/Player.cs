using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;
    public bool inTowerCollider = false;

    private void Start()
    {
        GetComponent<PlayerMovement>().speed = speed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
