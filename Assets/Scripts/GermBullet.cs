using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermBullet : MonoBehaviour
{
	public int power;
	Vector2 startAngle;
	Rigidbody2D rigidbody2D;

	private void Start()
	{
		startAngle = FindObjectOfType<Player>().transform.position - transform.position;
		rigidbody2D = GetComponent<Rigidbody2D>();
	}//이거 완성하기!!!!!!!!!!
	void FixedUpdate()
	{
		if (transform.position.y >= 5.15f || transform.position.y <= -5.15f)
		{
			Destroy(gameObject);
		}
		if (transform.position.x >= 4.26f || transform.position.y <= -9.04f)
		{
			Destroy(gameObject);
		}

		rigidbody2D.velocity = startAngle * power * Time.fixedDeltaTime;
	}
}
