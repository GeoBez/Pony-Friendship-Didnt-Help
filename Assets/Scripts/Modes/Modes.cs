using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modes// : MonoBehaviour
{
    public static string name;
    public static string description;
    //ссылка на карточку

    public static  bool isBlocked = false; //пригодится для ограничений
    public static bool isActive = false;

    /*private static Player player;
    private static Tower tree;
    private void Start()
    {
        player = GetComponent<Player>();
        tree = GameObject.FindGameObjectWithTag("Main Tower").GetComponent<Tower>();
    }*/
}

public class Mode_Magnit : Modes
{
    private void Start()
    {
        name = "Магнит";
        description = "Увеличивает радиус сбора монет";
    }
    public static void Activate()
    {
        //player.mode_Magnit = true;
        isActive = true;
        Coin.range = 12;        
    }
}
