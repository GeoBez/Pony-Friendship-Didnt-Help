using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject sprite;
    public float speed;
    public float lifetime;
    public float coolDown;
	public float distance;
    public float damage;
	public LayerMask whatIsSolid;
    private Transform _target;

    

    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
        _target = Weapon.target;
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        if (_target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target?.transform.position ?? transform.up, speed * Time.deltaTime); //самонаводка
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime); //летит в сторону направления взгляда
            _target = Weapon.target;
        } 

		if (hitInfo.collider != null)
		{
			if (hitInfo.collider.CompareTag("Enemy"))
            {
				hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);	
			}
			DestroyProjectile();
		}
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
