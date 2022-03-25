using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
	public GameObject enemyBullet;
	public float speed;
	float countTime;

	void Start()
	{
		speed = MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber - 1];
	}

	void Update()
	{
		transform.Translate(Vector3.down * Time.deltaTime * speed);
		
		countTime += Time.deltaTime;
		
		if (countTime < 1.5f) return;

		countTime = 0;
		GameObject game = Instantiate(enemyBullet, transform.position, Quaternion.identity);
		game.GetComponent<EnemyBullet>().power = 200;
		game.GetComponent<EnemyBullet>().startAngle = (FindObjectOfType<Player>().transform.position - transform.position).normalized;
		game.tag = "Germ1";
	}
}