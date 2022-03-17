using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
	public GameObject germBullet;
	public float speed;
	public float countTime;

	void Start()
	{
		speed = FindObjectOfType<MakeEnemy>().speedList[GetComponent<Enemy>().enemyNumber - 1];
	}

	void Update()
	{
		countTime += Time.deltaTime;
		if (countTime > 1)
		{
			countTime = 0;
			GameObject game = Instantiate(germBullet);
			game.transform.position = transform.position;
		}
		transform.Translate(Vector3.down * Time.deltaTime * speed);
	}
}