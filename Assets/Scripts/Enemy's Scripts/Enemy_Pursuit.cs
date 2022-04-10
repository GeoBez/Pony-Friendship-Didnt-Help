using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pursuit : MonoBehaviour
{
	public float speed;
	private Transform _target;
	public string target = "Player";

	void Start()
	{
		_target = GameObject.FindGameObjectWithTag(target).GetComponent<Transform>();
	}

	void Update()
	{
		if (_target != null)
		{
			transform.eulerAngles = _target.transform.position.x > transform.position.x ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
			transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
		}
	}
}