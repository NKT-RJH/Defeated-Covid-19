using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
	public GameObject enemyBullet;
	public bool count;
	public float speed;
	public float countTime;
	public float[] shotTime = { 2, 0.2f };

	void Start()
	{
		speed = MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber - 1];
	}

	void Update()
	{
		transform.Translate(Vector3.down * Time.deltaTime * speed);
		
		countTime += Time.deltaTime;
		
		if (countTime < shotTime[Convert.ToInt32(count)]) return;
		
		count = !count;
		countTime = 0;
		GameObject game = Instantiate(enemyBullet, transform.position, Quaternion.identity);
		game.GetComponent<EnemyBullet>().power = 220;
		game.GetComponent<EnemyBullet>().startAngle = (FindObjectOfType<Player>().transform.position - transform.position).normalized;
		game.tag = "Virus1";
	}
}