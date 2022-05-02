using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modes : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        //ActivateMagnite();
        //AcivateDoubleDenomination();
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
}
