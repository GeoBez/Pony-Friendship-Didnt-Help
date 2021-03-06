using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectile projectile;
    [SerializeField] public Transform shotPoint;
    private float _coolDown, _resetCoolDown;
    private static Collider2D[] targetsAtDetectionDistance;
    [NonSerialized] public Transform currentTarget;
    public float detectionDistance = 10;
    private float damage;
    public LayerMask whatIsAttack;
    public StatsBar attackCoolDownBar;

    void Start()
    {
        _coolDown = 0;
        _resetCoolDown = projectile.coolDown;
        attackCoolDownBar?.SetMaxValue(_resetCoolDown);

        if (gameObject.tag == "Player")
            damage = GetComponentInParent<Player>().Damage;
        else if (gameObject.tag == "Tower" || gameObject.tag == "Main Tower")
            damage = GetComponentInParent<Tower>().Damage;
    }
    void Update()
    {
        if (gameObject.tag == "Player")
            damage = GetComponentInParent<Player>().Damage;
        TargetSearch();

        if (currentTarget != null)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                Mathf.Atan2(currentTarget.position.y - transform.position.y,
                currentTarget.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }

        if (_coolDown <= 0 && currentTarget != null)
        {
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            _coolDown = _resetCoolDown;
        }
        else
        {
            _coolDown -= Time.deltaTime;
        }
        attackCoolDownBar?.SetValue(_resetCoolDown - _coolDown);
    }
    private void TargetSearch()
    {
        targetsAtDetectionDistance = Physics2D.OverlapCircleAll(shotPoint.position, detectionDistance, whatIsAttack);
        
        projectile.shot_Point = GetComponent<Weapon>();
        projectile.damage = damage;

        var tempList = new List<float>();
        for (int i = 0; i < targetsAtDetectionDistance.Length; i++)
        {
            tempList.Add(Vector2.Distance(targetsAtDetectionDistance[i].transform.position, shotPoint.position));
        }

        if (tempList.Count != 0) currentTarget = targetsAtDetectionDistance[tempList.IndexOf(tempList.Min())].transform;
        else currentTarget = null;
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(shotPoint.position, detectionDistance);
    }
}