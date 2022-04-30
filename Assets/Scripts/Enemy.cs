using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Range(0, 6)] public int enemyNumber;
	public int hp, maxhp;
	public bool hit;

	private void Start()
	{
		hp = MakeEnemy.hpList[enemyNumber];
		maxhp = hp;
		hit = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag != "Bullet") return;
		Destroy(collision.gameObject);
		StartCoroutine(Hit_Motion());
		hp -= FindObjectOfType<MakeBullet>().damage;
		if (hp <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void OnBecameInvisible()
	{
		if (hit)
		{
			Score.score += MakeEnemy.scoreList[enemyNumber];
			return;
		}
		if (FindObjectOfType<PlayerHurt>())
		{
			FindObjectOfType<PlayerHurt>().hurt += MakeEnemy.damageList[enemyNumber] / 2;
		}
		Destroy(gameObject);
	}

	IEnumerator Hit_Motion()
	{
		hit = true;
		if (gameObject.tag == "MiddleBoss2")
		{
			Color[] c = new Color[11];
			for (int i = 0; i < 11; i++)
			{
				c[i] = transform.GetChild(i).GetComponent<SpriteRenderer>().color;
			}
			for (int i = 0; i < 11; i++)
			{
				transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(c[i].r, c[i].g, c[i].b, 0.5f);
			}
			yield return new WaitForSeconds(0.1f);
			for (int i = 0; i < 11; i++)
			{
				transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(c[i].r, c[i].g, c[i].b, 1);
			}
		}
		else if (gameObject.tag != "Boss2")
		{
			if (gameObject.name != "BossDummy(Clone)")
			{
				Color c = GetComponent<SpriteRenderer>().color;
				GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 0.5f);
				yield return new WaitForSeconds(0.1f);
				GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 1);
			}
			else
			{
				Color[] c = new Color[4];
				for (int i = 0; i < 4; i++)
				{
					c[i] = transform.GetChild(i).GetComponent<SpriteRenderer>().color;
				}
				for (int i = 0; i < 4; i++)
				{
					transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(c[i].r, c[i].g, c[i].b, 0.5f);
				}
				yield return new WaitForSeconds(0.1f);
				for (int i = 0; i < 4; i++)
				{
					transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(c[i].r, c[i].g, c[i].b, 1);
				}
			}
		}
		else
		{
			Color[] c = new Color[6];
			for (int i = 0; i < 6; i++)
			{
				c[i] = transform.GetChild(i).GetComponent<SpriteRenderer>().color;
			}
			for (int i = 0; i < 6; i++)
			{
				transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(c[i].r, c[i].g, c[i].b, 0.5f);
			}
			yield return new WaitForSeconds(0.1f);
			for (int i = 0; i < 6; i++)
			{
				transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(c[i].r, c[i].g, c[i].b, 1);
			}
		}
		hit = false;
	}
}
