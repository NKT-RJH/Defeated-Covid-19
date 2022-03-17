using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	MakeEnemy makeEnemy;
	[Range(1, 5)]
	public int enemyNumber;
	int hp;
	bool hit;

	private void Start()
	{
		hit = false;
		makeEnemy = FindObjectOfType<MakeEnemy>();
		hp = makeEnemy.hpList[enemyNumber - 1];
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag != "Bullet") return;

		StopCoroutine(Hit_Motion());
		StartCoroutine(Hit_Motion());
		
		hp -= FindObjectOfType<MakeBullet>().damage;
		if (hp <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void OnBecameInvisible()
	{
		if (hit) return;
		FindObjectOfType<PlayerHurt>().hurt += makeEnemy.damageList[enemyNumber - 1] / 2;
		Destroy(gameObject);
	}

	IEnumerator Hit_Motion()
	{
		hit = true;

		float countTime = 0f;
		Color color;
		color.r = GetComponent<SpriteRenderer>().color.r;
		color.g = GetComponent<SpriteRenderer>().color.g;
		color.b = GetComponent<SpriteRenderer>().color.b;
		GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
		while(true)
		{
			countTime += Time.deltaTime;

			if (countTime >= 0.1f) break;

			yield return null;
		}
		GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1);

		hit = false;
	}
}
