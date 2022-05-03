using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modes : MonoBehaviour
{
    private Player player;
    private Tower tree;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        tree = GameObject.FindGameObjectWithTag("Main Tower").GetComponent<Tower>();
        //ActivateMagnite();
    }
    void ActivateMagnite()
    {
        player.mode_Magnit = true;
        Coin.range = 12;
    }
    void AcivateDoubleDenomination()
    {
        player.mode_Double_Denomination = true;
        Coin.coin_Denomination = 2;
    }
    void ActivateCleverLeaf()
    {
        player.mode_Clover_Leaf = true;
        Coin.probability = 40;
    }

    void ActivateMoreBits()
    {
        player.mode_MoreBits = true;
        Coin_Count_Text.coin_Count += 100;
    }

    void ActivateSturdy()
    {
        player.mode_Sturdy = true;
        player.maxHealth += (int)(player.maxHealth * 0.1);
        player.Health += (int)(player.maxHealth * 0.1);
    }

    void ActivateHealthyHealth()
    {
        player.mode_HealthyHealth = true;
        player.maxHealth += 20;
        player.Health += 20;
    }

    void ActivateNewHorseshoes()
    {
        player.mode_NewHorseshoes = true;
        player.speed += (float)(player.speed * 0.1);
    }

    void ActivateOneTimeTreatment()
    {
        player.mode_OneTimeTreatment = true;
        player.Health = player.maxHealth;
    }
    void ActivateMoreHealth()
    {
        Debug.Log(tree.maxHealth);
        player.mode_MoreHealth = true;
        tree.maxHealth += 20;
        tree.health += 20;
        Debug.Log(tree.maxHealth);
    }
}