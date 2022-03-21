using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float coolDown;
    public float damage;

	public LayerMask whatIsAttack;

    private Transform _target;
    private Vector2 _targetPosition;

    void Start()
    {
        Invoke(nameof(DestroyProjectile), lifetime);
        GetTarget();
    }


    void Update()
    {
        if (_target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition/*самонаводку сюда вместо _targetPosition*/, speed * Time.deltaTime); //самонаводка - _target?.transform.position ?? Vector2.up
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime); //летит в сторону направления взгляда...или нет)
            GetTarget(); //строка дает возможность уже выпущеному снаряду переключить цель
            //_target = Weapon.currentTarget; то же что и выше, но с самонаводкой
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            //TODO раскомментить collider.GetComponent<Enemy>().TakeDamage(damage); 
            DestroyProjectile();
        }
    }

    private void GetTarget()
    {
        _target = Weapon.currentTarget;
        if (_target != null) _targetPosition = new Vector2(_target.position.x, _target.position.y);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
