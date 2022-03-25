using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : MonoBehaviour
{
	public GameObject enemyBullet;
	public float speed;
	public float countTime;
	public int[] shotAngle = { 0, 3, -3 };

	void Start()
	{
		speed = MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber - 1];
	}

	void Update()
	{
		transform.Translate(Vector3.down * Time.deltaTime * speed);
		
		countTime += Time.deltaTime;
		
		if (countTime < 2.5f) return;
		
		countTime = 0;
		for (int i = 0; i < shotAngle.Length; i++)
		{
			GameObject game = Instantiate(enemyBullet, transform.position, Quaternion.identity);
			game.GetComponent<EnemyBullet>().power = 150;
			game.GetComponent<EnemyBullet>().startAngle = new Vector3(FindObjectOfType<Player>().transform.position.x - transform.position.x + shotAngle[i] / 10f, FindObjectOfType<Player>().transform.position.y - transform.position.y - Mathf.Abs(shotAngle[i] / 10f)).normalized;
			game.tag = "Cancer1";
		}
	}
}
