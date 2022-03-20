using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectile projectile;
    public Transform shotPoint;
    private float _coolDown, _resetCoolDown;

    public static Transform target;

    void Start()
    {
        _coolDown = projectile.coolDown;
        _resetCoolDown = projectile.coolDown;
        TargetSearch();
    }
    void Update()
    {
        if (_coolDown <= 0)
        {
            if (target != null)
            {
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            }
            else
            {
                TargetSearch();
            }
            _coolDown = _resetCoolDown;

        }
        else
        {
            _coolDown -= Time.deltaTime;
        }
    }
    public static void TargetSearch()
    {
        target = GameObject.FindGameObjectWithTag("Enemy")?.GetComponent<Transform>();
    }
}
