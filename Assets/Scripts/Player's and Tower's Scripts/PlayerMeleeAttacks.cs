using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMeleeAttacks : MonoBehaviour
{
    public float attackCoolDown;
    public StatsBar attackCoolDownBar;
    private bool isNeedRollback;
    private float currentAttackCoolDown;
    float attackDamage;
    public float attackRange;
    public LayerMask enemyLayer;
    [SerializeField] private Animator animator;
    
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        currentAttackCoolDown = attackCoolDown;
        attackCoolDownBar.SetMaxValue(attackCoolDown);
        attackDamage = GetComponentInParent<Player>().damage;
    }
    void Update()
    {
        if (currentAttackCoolDown >= attackCoolDown) TargetSearch();

        if (isNeedRollback) currentAttackCoolDown += Time.deltaTime;

        if (currentAttackCoolDown >= attackCoolDown)
        {
            isNeedRollback = false;
        }
        attackCoolDownBar.SetValue(currentAttackCoolDown);
    }

    private void Attack(Collider2D[] hitEnemies)
    {
        animator.SetTrigger("Attack");

        foreach(var enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>()?.TakeDamage(attackDamage);
        }

        isNeedRollback = true;
        currentAttackCoolDown = 0;
    }

    private void TargetSearch()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        if (hitEnemies.Length != 0) 
        {
            Attack(hitEnemies);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red - new Color(0, 0, 0, 0.9F);
        Gizmos.DrawSphere(transform.position, attackRange);
    }
}
