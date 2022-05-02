using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Text count_Coin_Text;
    private Rigidbody2D physic;
    private Transform player;
    private int speed=2;

    public static int coin_Denomination = 1;
    public static int range = 6;
    public static int probability=30;

    private void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Coin_Count_Text.coin_Count += coin_Denomination;              
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float dictanceToPlayer = Vector2.Distance(transform.position, player.position);
        //Debug.Log(dictanceToPlayer);

        if (dictanceToPlayer <= range)
        {
            ChasePlayer();
        }
        else physic.velocity = new Vector2(0, 0);
    }
    void ChasePlayer()
    {
        physic.velocity = new Vector2((player.position.x - transform.position.x)* speed, (player.position.y - transform.position.y)*speed);
    }
}
