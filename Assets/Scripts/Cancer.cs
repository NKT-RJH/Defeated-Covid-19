using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : MonoBehaviour
{
	public GameObject enemyBullet;
	float countTime;
	int[] shotAngle = { 0, 5, -5 };

    void Update()
    {
		if (!FindObjectOfType<MakeBloodCell>().dontMove)
			transform.Translate(Vector3.down * MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber] * Time.deltaTime);
		countTime += Time.deltaTime;
		if (countTime < 2.5f) return;
		countTime = 0;
		for (int i = 0; i < shotAngle.Length; i++)
		{
			GameObject g = Instantiate(enemyBullet, transform.position, Quaternion.identity);
			FindObjectOfType<MakeBloodCell>().enemyBulletList.Add(g);
			g.GetComponent<Bullet>().power = 150;
			g.GetComponent<Bullet>().startAngle = new Vector3(FindObjectOfType<Player>().transform.position.x - transform.position.x - (shotAngle[i] / 10f),
				FindObjectOfType<Player>().transform.position.y - transform.position.y - Mathf.Abs(shotAngle[i] / 10f)).normalized;
			g.tag = "Cancer1";
		}
    }
}
