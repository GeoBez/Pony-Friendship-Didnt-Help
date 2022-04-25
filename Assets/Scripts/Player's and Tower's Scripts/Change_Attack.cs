using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Attack : MonoBehaviour
{
    private void Start()
    {
        if(GetComponentInParent<Player>().isMeleeAttacker)
        {
            GetComponent<Melee_Attack>().enabled = true;
            GetComponent<Weapon>().enabled = false;
        }
        else
        {
            GetComponent<Melee_Attack>().enabled = false;
            GetComponent<Weapon>().enabled = true;
        }
    }
}
