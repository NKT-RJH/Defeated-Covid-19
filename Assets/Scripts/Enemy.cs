using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject bossHPBar;
	GameObject BarPrefab;
	[Range(1, 5)]
	public int enemyNumber;
	public int hp;
	public int maxhp;
	public bool hit;
	public int score;

	private void Start()
	{
		hit = false;
		if (tag == "Boss2")
		{
			BarPrefab = Instantiate(bossHPBar, GameObject.Find("Canvas").transform);
		}
		hp = MakeEnemy.hpList[enemyNumber - 1];
		maxhp = hp;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag != "Bullet") return;

		Destroy(collision.gameObject);

		StopCoroutine(Hit_Motion());
		StartCoroutine(Hit_Motion());
		
		hp -= FindObjectOfType<MakeBullet>().damage;
		if (hp <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void If_Boss()
	{
		if (tag == "Boss2")
		{
			Destroy(BarPrefab);
			FindObjectOfType<Stage>().End_Stage();
		}
	}

	private void OnBecameInvisible()
	{
		if (hit)
		{
			Score.score += score;
			If_Boss();
			return;
		}
		if (FindObjectOfType<PlayerHurt>())
		{
			FindObjectOfType<PlayerHurt>().hurt += MakeEnemy.damageList[enemyNumber - 1] / 2;
		}
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
