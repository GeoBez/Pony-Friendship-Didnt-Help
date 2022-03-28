using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Projectile : MonoBehaviour
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
            transform.position = Vector2.MoveTowards(transform.position, _target?.transform.position ?? Vector2.up /*_targetPosition*//*����������� ���� ������ _targetPosition*/, speed * Time.deltaTime); //����������� - _target?.transform.position ?? Vector2.up
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime); //����� � ������� ����������� �������...��� ���)
            GetTarget(); //������ ���� ����������� ��� ���������� ������� ����������� ����
            //_target = Weapon.currentTarget; �� �� ��� � ����, �� � ������������
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Tower_Enemy")
        {
            collider.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }
    }

    private void GetTarget()
    {
        _target = Tower_Weapon.currentTarget;
        if (_target != null) _targetPosition = new Vector2(_target.position.x, _target.position.y);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
