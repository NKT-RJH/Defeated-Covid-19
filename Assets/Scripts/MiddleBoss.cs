using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoss : MonoBehaviour
{
	public GameObject[] enemyList = new GameObject[2];
	public GameObject bossHPBar;
	float countTime;

	// Start is called before the first frame update
	void Start()
	{
		Instantiate(bossHPBar, GameObject.Find("Canvas").transform);
	}

	// Update is called once per frame
	void Update()
	{
		countTime += Time.deltaTime;
		if (countTime <= 1.5f) return;
		countTime = 0;
		Spawn_Enemy();
	}

	private void OnDestroy()
	{
		FindObjectOfType<MakeEnemy>().fighting = false;
	}

	void Spawn_Enemy()
	{
		int r = Random.Range(0, 2);
		if (r == 0)
			FindObjectOfType<CheatKey>().enemyList.Add(Instantiate(enemyList[Random.Range(0, 2)], new Vector3(transform.position.x - 2, transform.position.y), Quaternion.identity));
		if (r == 1)
			FindObjectOfType<CheatKey>().enemyList.Add(Instantiate(enemyList[Random.Range(0, 2)], new Vector3(transform.position.x + 2, transform.position.y), Quaternion.identity));
	}
}
