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
    private float rotateSpeed = 200F;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(DestroyProjectile), lifetime);
        GetTarget();

        rb.velocity = new Vector2((_target.position.x - transform.position.x) * speed, (_target.position.y - transform.position.y) * speed);
    }


    void FixedUpdate()
    {
        /*if (_target != null)
        {
            Vector2 direction = (Vector2)_target.position - rb.position;
            float rotateAmount = Vector3.Cross(direction.normalized, transform.right).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
        }
        else
        {
            rb.angularVelocity = 0;
            //GetTarget(); //строка дает возможность уже выпущеному снаряду переключить цель
            //_target = Weapon.currentTarget; то же что и выше, но с самонаводкой
        }
        rb.velocity = transform.right * speed;*/
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
