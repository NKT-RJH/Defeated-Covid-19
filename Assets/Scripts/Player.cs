using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	PlayerHP playerHP;

	public bool isCantBreak, onCantBreak;

	string[] enemyList;
	int[] damageList;

	private void Awake()
	{
		playerHP = FindObjectOfType<PlayerHP>();
		isCantBreak = false;
		onCantBreak = false;
	}

	void Start()
    {
		enemyList = FindObjectOfType<MakeEnemy>().nameList;
		damageList = FindObjectOfType<MakeEnemy>().damageList;
    }

	private void Update()
	{
		if (!isCantBreak) return;

		StopCoroutine(On_Cant_Break(false));
		StartCoroutine(On_Cant_Break(false));
		isCantBreak = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//적일 떄만 효과 발생하기
		if (onCantBreak) return;

		for (int i = 0; i < enemyList.Length; i++)
		{
			//데미지 설정하기
			for (int j = 1; j <= 2; j++)
			{
				if (collision.tag != enemyList[i]+j) continue;

				playerHP.HP -= damageList[i] / j;
				StartCoroutine(On_Cant_Break(true));
				i = enemyList.Length; //중첩for문 break
				break;
			}
		}
	}

	IEnumerator On_Cant_Break(bool isHit)
	{
		float endTime = 0f, countTime = 0f;

		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

		while (true)
		{
			if (endTime > 1.5f) break;
			else endTime += Time.deltaTime;
		
			countTime += Time.deltaTime;

			if (isHit)
			{
				if (countTime < 0.5f)
				{
					GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - countTime);
				}
				else
				{
					GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, countTime);
					if (countTime > 1f)
					{
						countTime -= 1f;
					}
				}
			}
			else
			{
				if (countTime <= 2.5)
				{
					spriteRenderer.color = Color.blue;
				}
				else
				{
					if (countTime > 3) break;

					spriteRenderer.color = new Color(1, 1, 1, 1);
				}
			}
			
			onCantBreak = true;

			yield return null;
		}
		GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
		onCantBreak = false;
	}
}
