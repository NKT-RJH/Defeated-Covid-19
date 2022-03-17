using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public int power;
	[HideInInspector] public Vector2 startAngle;
	Rigidbody2D rigidbody2D;

	private void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		rigidbody2D.velocity = startAngle * power * Time.fixedDeltaTime;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 3 || collision.tag == "Player") return;
		
		Destroy(gameObject);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
