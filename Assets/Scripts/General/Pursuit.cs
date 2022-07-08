using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour
{
	public float speed;
	private Transform _target;
	public string target;

	private Animator _animator;

	void Awake()
	{
		_animator = GetComponent<Animator>();
		_target = GameObject.FindGameObjectWithTag(target)?.GetComponent<Transform>();
		if(gameObject.tag == "Enemy" || gameObject.tag == "Boss")
			speed = GetComponent<Enemy>().Speed;
	}

	void Update()
	{
		if (_target != null)
		{
			if(_animator != null) _animator?.SetBool("isWalking", true);
			transform.eulerAngles = _target.transform.position.x > transform.position.x ? new Vector3(0, 0, 0) : new Vector3(0, 180, 0);
			transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
		}
		else if (_animator != null) _animator?.SetBool("isWalking", false);

		if (gameObject.tag == "Enemy" || gameObject.tag == "Boss")
		{
			Enemy enemy = GetComponentInParent<Enemy>();
			if (enemy && speed != enemy.Speed)
				speed = enemy.Speed;
		}
	}
}