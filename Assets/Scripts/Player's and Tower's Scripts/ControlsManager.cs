using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public FreezeUlt freezeUlt;
    public Tower_UI tower_UI;
    public 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            freezeUlt.TryUse();
        }
        if (Input.GetKeyDown(KeyCode.F)){
            tower_UI.CreateTower();
        }
    }
}
