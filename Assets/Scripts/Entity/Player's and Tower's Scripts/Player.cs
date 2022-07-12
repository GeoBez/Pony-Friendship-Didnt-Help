using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public static Player MainPlayer;

    [SerializeField] private Text atackUi;

    public bool inTowerCollider = false;

    public static bool mode_YouShallNotPass;
    public static bool mode_YouShallNoPass = false;
    public bool isMeleeAttacker;

    float immortality_Timer = .5f;
    float default_Immortality_Timer;

    Change_Attack change_Attack;

    protected override void OnAwake()
    {
        GetComponentInChildren<Weapon>().projectile.coolDown = 0.7F;

        change_Attack = GetComponentInChildren<Change_Attack>();

        GetComponent<PlayerMovement>().speed = Speed;
              
        //isMeleeAttacker = true;
        if (isMeleeAttacker)
            change_Attack.ChangeAttack();

        gameObject.AddComponent<Mode_YouShallNoPass>().Activate();
        //new Mode_MoreBits().Activate();
        //gameObject.AddComponent<Mode_YouShallNoPass>().Activate();
        default_Immortality_Timer = immortality_Timer;

        EventChangeDamage.AddListener(str => atackUi.GetComponent<AtackPowerText>().UpdateText(str));

        EventTakeHit.AddListener(() => StartCoroutine(RemoveImmortality()));
    }

    private IEnumerator RemoveImmortality()
    {
        yield return new WaitForSeconds(default_Immortality_Timer);
        isImmortality = true;
        yield break;
    }

    public override void Death()
    {
        Set_Game_Over.SetActive();
    }
}
