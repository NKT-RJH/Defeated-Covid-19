using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
	public GameObject[] enemyList = new GameObject[5];
	public string[] nameList = new string[5];
	public static int[] damageList = new int[5];
	public static float[] speedList = new float[5];
	public static int[] hpList = new int[5];

	public float spawnTime, countTime, countBossTime;
	public int bossTime;

	private void Awake()
	{
		if (Stage.stage == 0)
		{
			damageList[0] = 10;
			damageList[1] = 6;
			damageList[2] = 6;
			damageList[3] = 8;
			damageList[4] = 10;

			hpList[0] = 10;
			hpList[1] = 30;
			hpList[2] = 40;
			hpList[3] = 50;
			hpList[4] = 1500;
		}
		if (Stage.stage == 1)
		{
			damageList[0] = 12;
			damageList[1] = 8;
			damageList[2] = 8;
			damageList[3] = 10;
			damageList[4] = 12;

			hpList[0] = 15;
			hpList[1] = 35;
			hpList[2] = 45;
			hpList[3] = 55;
			hpList[4] = 3000;
		}

		speedList[0] = 6;
		speedList[1] = 0.8f;
		speedList[2] = 1;
		speedList[3] = 0.6f;
		speedList[4] = 0.2f;
	}

	void Update()
    {
		if (countTime == 0)
		{
			spawnTime = Random.Range(3f, 5f);
		}

		countTime += Time.deltaTime;
		countBossTime += Time.deltaTime;

		if (countTime >= spawnTime)
		{
			countTime = 0;
			int num = Random.Range(1, enemyList.Length);
			float path = Random.Range(-8f, 3f);
			FindObjectOfType<CheatKey>().enemys.Add(Instantiate(enemyList[num - 1], new Vector3(path, 5, 0), Quaternion.identity));
		}
		if (countBossTime >= bossTime)
		{
			FindObjectOfType<CheatKey>().enemys.Add(Instantiate(enemyList[4], new Vector3(-2.39f, 6.5f, 0), Quaternion.identity));
			enabled = false;
		}
    }
}
