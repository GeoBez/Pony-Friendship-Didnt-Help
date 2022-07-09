using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Script : MonoBehaviour
{
    public Transform Target;
    public bool isAttacking;

    public GameObject[] Attacks;

    Enemy enemy_Script;

    public int rnd;
    int pastAttack;
    int AttackVariant;

    public Transform laserTransform;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Boss_Target").transform;
        Target.GetComponent<Boss_Target>().boss = this;
        enemy_Script = GetComponent<Enemy>();
        rnd = Random.Range(0, 100);
        pastAttack = -1;
        for (int i = 0; i < Attacks.Length; i++)
        {
            Attacks[i].SetActive(false);
        }

    }

    private void Update()
    {
        if (rnd < 30)
        {
            AttackVariant = 0;
            Target = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
        else if (rnd >= 30 && rnd < 80)
            AttackVariant = 1;
        else if (rnd < 100 && rnd >= 80)
            AttackVariant = 2;

        if (pastAttack == AttackVariant)
            if (AttackVariant == 0)
                AttackVariant += 1;
            else
                AttackVariant -= 1;

        if (enemy_Script.attackTime <= 0)
            isAttacking = true;

        if (isAttacking)
        {
            Attacks[AttackVariant].SetActive(true);
            if (AttackVariant == 0)
                Rotation_Character();
        }
        else if (!isAttacking)
        {
            Rotation_Character();
            enemy_Script.attackTime -= Time.deltaTime;
        }
    }

    void Rotation_Character()
    {
        if (Target == null) return;
        laserTransform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((Target.position.y - transform.position.y), (Target.position.x - transform.position.x)) * Mathf.Rad2Deg);
    }

    public void RandomAttacks()
    {
        pastAttack = rnd;
        Target = GameObject.FindGameObjectWithTag("Boss_Target").transform;
        rnd = Random.Range(0, 100);
    }
}
