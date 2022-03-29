using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int power;
	public Vector3 startAngle;
	Rigidbody2D rigidbody2D;

	private void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		rigidbody2D.velocity = startAngle * power * Time.fixedDeltaTime;
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
