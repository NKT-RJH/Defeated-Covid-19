using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
	public GameObject germBullet;
	public int speed;
	public float countTime;

	void Start()
	{
		speed = FindObjectOfType<MakeEnemy>().speedList[0];
	}

	void Update()
	{
		countTime = Time.deltaTime;
		if (countTime > 0.5f)
		{
			countTime = 0;
			Instantiate(germBullet);
		}
		transform.Translate(Vector3.down * Time.deltaTime * speed);
	}
}
