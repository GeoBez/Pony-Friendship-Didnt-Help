using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectile projectile;
    [SerializeField] private Transform shotPoint;
    private float _coolDown, _resetCoolDown;
    private static Collider2D[] targetsAtDetectionDistance;
    [NonSerialized] public Transform currentTarget;
    public float detectionDistance = 10;

    void Start()
    {
        _coolDown = 0;
        _resetCoolDown = projectile.coolDown;
        //TargetSearch();
    }
    void Update()
    {
        TargetSearch();
        if (_coolDown <= 0 && currentTarget != null)
        {
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            _coolDown = _resetCoolDown;
        }
        else
        {
            _coolDown -= Time.deltaTime;
        }
    }
    private void TargetSearch()
    {
        targetsAtDetectionDistance = Physics2D.OverlapCircleAll(shotPoint.position, detectionDistance,  projectile.whatIsAttack);

        projectile.shot_Point = GetComponent<Weapon>();

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