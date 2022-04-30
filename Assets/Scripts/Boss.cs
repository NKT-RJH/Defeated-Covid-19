using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	public GameObject[] enemyList = new GameObject[5];
	public GameObject bossBullet;
	public GameObject bossHPBar;
	float countTime, randTime = 3;
	
    // Start is called before the first frame update
    void Start()
    {
		Instantiate(bossHPBar, GameObject.Find("Canvas").transform);
    }

    // Update is called once per frame
    void Update()
    {
		countTime += Time.deltaTime;
		if (countTime < randTime) return;
		countTime = 0;
		randTime = Random.Range(3f, 5);
		switch(Random.Range(0,4))
		{
			case 0:
				StartCoroutine(Circle_Shot());
				break;
			case 1:
				Spawn_Enemy();
				break;
			case 2:
				StartCoroutine(Spin_Shot());
				break;
			case 3:
				StartCoroutine(ShotGun_Shot());
				break;
		}
    }

	private void OnDestroy()
	{
		if (FindObjectOfType<PlayerGoToNext>())
		{
			FindObjectOfType<PlayerGoToNext>().enabled = true;
		}
	}

	IEnumerator Circle_Shot()
	{
		for (int i = 0; i <= Stage.stage; i++)
		{
			for (int j = 0; j < 360; j += 15)
			{
				FindObjectOfType<MakeBloodCell>().enemyBulletList.Add(Instantiate(bossBullet, transform.position, Quaternion.Euler(0, 0, j)));
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	void Spawn_Enemy()
	{
		FindObjectOfType<CheatKey>().enemyList.Add(Instantiate(enemyList[Random.Range(0, 5)], new Vector3(transform.position.x - 3, transform.position.y), Quaternion.identity));
		FindObjectOfType<CheatKey>().enemyList.Add(Instantiate(enemyList[Random.Range(0, 5)], new Vector3(transform.position.x + 3, transform.position.y), Quaternion.identity));
	}

	IEnumerator Spin_Shot()
	{
		for (int i = 0; i <= Stage.stage; i++)
		{
			for (int j = 0; j < 360; j += 15)
			{
				FindObjectOfType<MakeBloodCell>().enemyBulletList.Add(Instantiate(bossBullet, transform.position, Quaternion.Euler(0, 0, j)));
				yield return new WaitForSeconds(0.01f);
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator ShotGun_Shot()
	{
		int angle = Random.Range(220, 300 + 1);
		for (int i = 0; i <= Stage.stage; i++)
		{
			for (int j = 210; j <= 330; j += 10)
			{
				if (!(j >= angle && j <= angle + 20))
					FindObjectOfType<MakeBloodCell>().enemyBulletList.Add(Instantiate(bossBullet, transform.position, Quaternion.Euler(0, 0, j)));
				//yield return new WaitForSeconds(0.01f);
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
}
