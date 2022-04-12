using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float coolDown;
    public float damage;

	public LayerMask whatIsAttack;
    public Weapon shot_Point;

    private Transform _target;
    private Vector2 _targetPosition;

    Rigidbody2D rb;
    private float rotateSpeed = 600F;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(DestroyProjectile), lifetime);
        GetTarget();
    }



    void FixedUpdate()
    {
        if (_target != null)
        {
            Vector2 direction = (Vector2)_targetPosition - rb.position;
            float rotateAmount = Vector3.Cross(direction.normalized, transform.right).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.right * speed;
        }
        else
        {
            GetTarget(); //строка дает возможность уже выпущеному снаряду переключить цель
            //_target = Weapon.currentTarget; то же что и выше, но с самонаводкой
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") || collider.CompareTag("Tower_Enemy"))
        {
            collider.GetComponent<Enemy>().TakeDamage(damage); 
            DestroyProjectile();
        }
    }

    private void GetTarget()
    {
        _target = shot_Point.currentTarget;
        if (_target != null) _targetPosition = new Vector2(_target.position.x, _target.position.y);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
