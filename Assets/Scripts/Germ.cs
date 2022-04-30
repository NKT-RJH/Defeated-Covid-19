using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
	public GameObject enemyBullet;
	float countTime;

	void Update()
	{
		if (!FindObjectOfType<MakeBloodCell>().dontMove)
			transform.Translate(Vector3.down * MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber] * Time.deltaTime);
		countTime += Time.deltaTime;
		if (countTime < 1.5f) return;
		countTime = 0;
		GameObject g = Instantiate(enemyBullet, transform.position, Quaternion.identity);
		FindObjectOfType<MakeBloodCell>().enemyBulletList.Add(g);
		g.GetComponent<Bullet>().power = 200;
		g.GetComponent<Bullet>().startAngle = (FindObjectOfType<Player>().transform.position - transform.position).normalized;
		g.tag = "Germ1";
	}
}
