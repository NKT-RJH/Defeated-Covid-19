using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public bool isCantBreak, onCantBreak;
	Coroutine c;

    void Update()
    {
		if (!isCantBreak) return;
		if (c == null)
			c = StartCoroutine(On_Cant_Break(false));
		isCantBreak = false;
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (FindObjectOfType<PlayerGoToNext>().isEnd) return;
		if (isCantBreak || onCantBreak) return;
		for (int i = 0; i < MakeEnemy.nameList.Length; i++)
		{
			for (int j = 1; j <= 2; j++)
			{
				if (collision.tag != MakeEnemy.nameList[i] + j) continue;
				if (j == 1)
				{
					Destroy(collision.gameObject);
				}
				if (c == null)
					c = StartCoroutine(On_Cant_Break(true));
				if (FindObjectOfType<PlayerHP>())
				{
					FindObjectOfType<PlayerHP>().HP -= MakeEnemy.damageList[i] / j;
				}
				i = MakeEnemy.nameList.Length;
				break;
			}
		}
	}

	IEnumerator On_Cant_Break(bool e)
	{
		onCantBreak = true;

		if (e)
		{
			bool o = false;
			for (int i = 0; i < 15; i++)
			{
				GetComponent<SpriteRenderer>().enabled = o;
				o = !o;
				yield return new WaitForSeconds(0.1f);
			}
			GetComponent<SpriteRenderer>().enabled = true;
		}
		else
		{
			float countTime = 0;
			while (countTime <= 3)
			{
				countTime += Time.deltaTime;
				GetComponent<SpriteRenderer>().color = Color.green;
				if (countTime >= 2.5f)
					GetComponent<SpriteRenderer>().color = Color.white;
				yield return null;
			}
		}
		onCantBreak = false;
		c = null;
	}
}
