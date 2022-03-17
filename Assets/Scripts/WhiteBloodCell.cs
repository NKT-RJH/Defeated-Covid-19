using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
	[SerializeField] GameObject itemPrefab;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		bool isOn = false;
		if (collision.tag == "Bullet" || collision.tag == "Player") isOn = true;
		if (!isOn) return;

		GameObject game = Instantiate(itemPrefab);
		game.transform.position = transform.position;
		Destroy(gameObject);
	}
}