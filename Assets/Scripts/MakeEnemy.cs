using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
	public GameObject[] enemyList = new GameObject[7];
	public static string[] nameList = new string[7];
	public static int[] damageList = new int[7];
	public static float[] speedList = new float[7];
	public static int[] hpList = new int[7];
	public static int[] scoreList = new int[7];
	float countTime, spawnTime = 3, countBossTime, countMiddleBossTime;
	public bool fighting, dontSpawn;
	int bossTime, middleBossTime;

	private void Awake()
	{
		if (Stage.stage == 0)
		{
			middleBossTime = 30;
			bossTime = 60;
			damageList[0] = 10;
			damageList[1] = 6;
			damageList[2] = 6;
			damageList[3] = 8;
			damageList[4] = 6;
			damageList[5] = 10;
			damageList[6] = 8;

			hpList[0] = 10;
			hpList[1] = 30;
			hpList[2] = 40;
			hpList[3] = 50;
			hpList[4] = 5;
			hpList[5] = 1500;
			hpList[6] = 750;

			scoreList[0] = 300;
			scoreList[1] = 750;
			scoreList[2] = 1000;
			scoreList[3] = 1500;
			scoreList[4] = 100;
			scoreList[5] = 10000;
			scoreList[6] = 5000;
		}
		if (Stage.stage == 1)
		{
			middleBossTime = 45;
			bossTime = 90;
			damageList[0] = 12;
			damageList[1] = 8;
			damageList[2] = 8;
			damageList[3] = 10;
			damageList[4] = 6;
			damageList[5] = 12;
			damageList[6] = 10;

			hpList[0] = 15;
			hpList[1] = 40;
			hpList[2] = 50;
			hpList[3] = 60;
			hpList[4] = 5;
			hpList[5] = 3000;
			hpList[6] = 1500;

			scoreList[0] = 500;
			scoreList[1] = 100;
			scoreList[2] = 1500;
			scoreList[3] = 2000;
			scoreList[4] = 200;
			scoreList[5] = 20000;
			scoreList[6] = 10000;
		}
		nameList[0] = "Bacteria";
		nameList[1] = "Germ";
		nameList[2] = "Virus";
		nameList[3] = "Cancer";
		nameList[4] = "Snail";
		nameList[5] = "Boss";
		nameList[6] = "MiddleBoss";

		speedList[0] = 5;
		speedList[1] = 0.8f;
		speedList[2] = 1;
		speedList[3] = 0.6f;
		speedList[4] = 8;
		speedList[5] = 0.2f;
		speedList[6] = 0.5f;
	}

	// Update is called once per frame
	void Update()
    {
		if (fighting) return;
		countTime += Time.deltaTime;
		countMiddleBossTime += Time.deltaTime;
		countBossTime += Time.deltaTime;
		if (countTime >= spawnTime)
		{
			countTime = 0;
			spawnTime = Random.Range(2.5f, 4);
			int n = Random.Range(0, 5);
			if (n == 4)
				FindObjectOfType<CheatKey>().enemyList.Add(Instantiate(enemyList[n], new Vector3(-9, Random.Range(4f, 0)), Quaternion.Euler(0, 0, 90)));
			else
				FindObjectOfType<CheatKey>().enemyList.Add(Instantiate(enemyList[n], new Vector3(Random.Range(-7f, 7), 5), Quaternion.identity));
		}
		if (countMiddleBossTime >= middleBossTime && !dontSpawn)
		{
			FindObjectOfType<CheatKey>().enemyList.Add(Instantiate(enemyList[6], new Vector3(0, 6.5f), Quaternion.identity));
			dontSpawn = true;
		}
		if (countBossTime >= bossTime)
		{
			FindObjectOfType<CheatKey>().enemyList.Add(Instantiate(enemyList[5], new Vector3(0, 6.5f), Quaternion.identity));
		}
    }
}
