using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
	public GameObject[] enemyList = new GameObject[5];
	public GameObject bossBullet;
	float countTime;
	float randTime;

    void Start()
    {
		randTime = Random.Range(2f, 3.5f);
    }

    void Update()
    {
		countTime += Time.deltaTime;

		if (countTime < randTime) return;

		countTime = 0;
		randTime = Random.Range(2f, 3.5f);
		switch (Random.Range(1, 3 + 1))
		{
			case 1:
				StartCoroutine(Circle_Shot());
				break;
			case 2:
				Spawn_Monster();
				break;
			case 3:
				StartCoroutine(Spin_Shot());
				break;
		}
	}

	IEnumerator Circle_Shot()
	{
		for (int j = 0; j < Stage.stage + 1; j++)
		{
			for (int i = 0; i < 360; i += 15)
			{
				Instantiate(bossBullet, transform.position, Quaternion.Euler(0, 0, i));
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
	void Spawn_Monster()
	{
		Instantiate(enemyList[Random.Range(0, 5)], new Vector3(transform.position.x + 3, transform.position.y, 0), Quaternion.identity);
		Instantiate(enemyList[Random.Range(0, 5)], new Vector3(transform.position.x - 3, transform.position.y, 0), Quaternion.identity);
		randTime = 3;
	}
	IEnumerator Spin_Shot()
	{
		for (int j = 0; j < Stage.stage + 1; j++)
		{
			for (int i = 0; i < 360; i += 15)
			{
				Instantiate(bossBullet, transform.position, Quaternion.Euler(0, 0, i));
				yield return null;
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
}