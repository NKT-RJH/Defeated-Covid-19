using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour
{
	public float speed = 2;

	void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		bool i = false;
		if (collision.tag == "Bullet" || collision.tag == "Player") i = true;
		if (!i) return;
		if (FindObjectOfType<PlayerHurt>())
		{
			FindObjectOfType<PlayerHurt>().hurt += 8;
		}
		Destroy(gameObject);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
