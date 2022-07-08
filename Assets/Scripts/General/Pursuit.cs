using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour
{
	public float speed;
	private Transform _target;
	public string target;

	private Animator _animator;

	void Start()
	{
		_animator = GetComponent<Animator>();
		_target = GameObject.FindGameObjectWithTag(target)?.GetComponent<Transform>();
		if(gameObject.tag == "Enemy" || gameObject.tag == "Boss")
			speed = GetComponent<Enemy>().speed;
	}

	void Update()
	{
		if (_target != null)
		{
			if(_animator != null) _animator?.SetBool("isWalking", true);
			transform.localEulerAngles = _target.transform.position.x > transform.position.x ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
			transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
		}
		else if (_animator != null) _animator?.SetBool("isWalking", false);

		if (gameObject.tag == "Enemy" || gameObject.tag == "Boss")
			if(speed != GetComponent<Enemy>().speed)
				speed = GetComponent<Enemy>().speed;
	}
}