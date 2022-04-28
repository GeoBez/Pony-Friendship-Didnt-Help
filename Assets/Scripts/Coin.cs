using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Text count_Coin_Text;

    public int coin_Denomination = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Coin_Count_Text.coin_Count += coin_Denomination;              
            Destroy(gameObject);
        }
    }
}
