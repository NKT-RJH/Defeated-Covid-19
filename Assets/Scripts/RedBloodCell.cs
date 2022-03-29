using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour
{
	public float speed;

	private void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		bool isOn = false;
		if (collision.tag == "Bullet" || collision.tag == "Player") isOn = true;
		if (!isOn) return;

		FindObjectOfType<PlayerHurt>().hurt += 8;
		Destroy(gameObject);
	}
}
