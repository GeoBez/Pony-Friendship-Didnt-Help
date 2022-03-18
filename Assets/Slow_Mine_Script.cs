using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Mine_Script : MonoBehaviour
{
    Player_Movement _Movement;

    private void Start()
    {
        _Movement = GetComponent<Player_Movement>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slow Mine")
        {
            _Movement.speed = _Movement.speed / 2;
        }
    }
}
