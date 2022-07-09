using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public FreezeUlt freezeUlt;
    public Tower_UI tower_UI;
    public GameObject preporation;
    public 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            freezeUlt.TryUse();
        }
        if (Input.GetKeyDown(KeyCode.F)){
            tower_UI.CreateTower();
        }
        if (Input.GetKeyDown(KeyCode.C) && preporation.activeSelf)
        {
            //Preparation_Script.
            preporation.GetComponent<Preparation_Script>().End_Time();
        }

    }
}
