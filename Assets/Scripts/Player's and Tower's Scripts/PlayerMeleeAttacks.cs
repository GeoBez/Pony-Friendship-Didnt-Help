using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMeleeAttacks : MonoBehaviour
{
    public float attackCoolDown;
    public StatsBar attackCoolDownBar;
    private bool _isNeedRollback;
    private float _currentAttackCoolDown;
    float attackDamage;
    public float attackRange;
    public LayerMask enemyLayer;
    [SerializeField] private Animator animator;
    [SerializeField] GameObject Melee_Damage_Effect;
    
    public void SetCoolDown(float coolDown)
    {
        if (coolDown > 0)
        {
            _currentAttackCoolDown = coolDown;
            attackCoolDown = coolDown;
            attackCoolDownBar.SetMaxValue(attackCoolDown);
        }
        else throw new System.Exception("You tried to set under 0 coolDown");
    }
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        _currentAttackCoolDown = attackCoolDown;
        attackCoolDownBar.SetMaxValue(attackCoolDown);
        attackDamage = GetComponentInParent<Player>().Damage;
    }
    void Update()
    {
        if (_currentAttackCoolDown >= attackCoolDown) TargetSearch();

        if (_isNeedRollback) _currentAttackCoolDown += Time.deltaTime;

        if (_currentAttackCoolDown >= attackCoolDown)
        {
            _isNeedRollback = false;
        }
        attackCoolDownBar.SetValue(_currentAttackCoolDown);
    }

    private void Attack(Collider2D[] hitEnemies)
    {
        //animator.SetTrigger("Attack");

        foreach (var enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>()?.TakeDamage(attackDamage);
            Instantiate(Melee_Damage_Effect, enemy.transform.position, Quaternion.identity);
        }

        _isNeedRollback = true;
        _currentAttackCoolDown = 0;
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
