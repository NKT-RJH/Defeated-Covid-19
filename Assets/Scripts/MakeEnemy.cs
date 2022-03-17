using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
	public GameObject[] enemyList = new GameObject[5];
	public string[] nameList = new string[5];
	public int[] damageList = new int[5];
	public float[] speedList = new float[5];
	public int[] hpList = new int[5];

	public float spawnTime, countTime, countBossTime;
	public int bossTime;

	void Update()
    {
		if (countTime == 0)
		{
			spawnTime = Random.Range(1f, 3f);
		}
		countTime += Time.deltaTime;
		countBossTime += Time.deltaTime;
		if (countTime >= spawnTime)
		{
			countTime = 0;
			//int num = Random.Range(1, 5 + 1);
			int num = Random.Range(1, 2 + 1);
			float path = Random.Range(-8f, 3f);
			Instantiate(enemyList[num - 1], new Vector3(path, 5, 0), Quaternion.identity);
		}
		if (countBossTime >= bossTime)
		{
			print("BossTime!!!");
			enabled = false;
		}
    }
}
