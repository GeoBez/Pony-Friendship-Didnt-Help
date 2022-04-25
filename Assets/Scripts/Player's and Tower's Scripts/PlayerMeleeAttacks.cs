using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMeleeAttacks : MonoBehaviour
{
    public float attackCoolDown;
    public HealthBar attackCoolDownBar;
    private bool isNeedCountdown;
    private float currentAttackCoolDown;
    float attackDamage;
    public float attackRange;
    public LayerMask enemyLayer;
    [SerializeField] private Animator animator;
    
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        currentAttackCoolDown = attackCoolDown;
        attackCoolDownBar.SetMaxHealth(attackCoolDown);
        attackDamage = GetComponentInParent<Player>().damage;
    }
    void Update()
    {
        if (currentAttackCoolDown == attackCoolDown) TargetSearch();

        if (isNeedCountdown) currentAttackCoolDown -= Time.deltaTime;

        if (currentAttackCoolDown <= 0)
        {
            isNeedCountdown = false;
            currentAttackCoolDown = attackCoolDown;
        }
        attackCoolDownBar.SetHealth(currentAttackCoolDown);
    }

    private void Attack(Collider2D[] hitEnemies)
    {
        animator.SetTrigger("Attack");

        foreach(var enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>()?.TakeDamage(attackDamage);
        }

        isNeedCountdown = true;
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
