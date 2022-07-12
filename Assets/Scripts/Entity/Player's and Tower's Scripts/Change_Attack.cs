using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Attack : MonoBehaviour
{
    public void ChangeAttack()
    {
        if(GetComponentInParent<Player>().isMeleeAttacker)
        {
            GetComponent<PlayerMeleeAttacks>().enabled = true;
            GetComponent<Weapon>().enabled = false;
        }
        else
        {
            GetComponent<PlayerMeleeAttacks>().enabled = false;
            GetComponent<Weapon>().enabled = true;
        }
    }
}
