using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
	public GameObject enemyBullet;
	float countTime;
	bool count;
	float[] shotTime = { 2, 0.2f };

	void Update()
	{
		if (!FindObjectOfType<MakeBloodCell>().dontMove)
			transform.Translate(Vector3.down * MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber] * Time.deltaTime);
		countTime += Time.deltaTime;
		if (countTime < shotTime[Convert.ToInt32(count)]) return;
		countTime = 0;
		count = !count;
		GameObject g = Instantiate(enemyBullet, transform.position, Quaternion.identity);
		FindObjectOfType<MakeBloodCell>().enemyBulletList.Add(g);
		g.GetComponent<Bullet>().power = 200;
		g.GetComponent<Bullet>().startAngle = (FindObjectOfType<Player>().transform.position - transform.position).normalized;
		g.tag = "Virus1";
	}
}
