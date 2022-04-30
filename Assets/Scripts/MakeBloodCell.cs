using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBloodCell : MonoBehaviour
{
	public GameObject bloodCell;
	[Range(0, 100)] public int chance;
	int number;
	float countTime, countMove;
	public List<GameObject> enemyBulletList = new List<GameObject>(); //몬스터들 총알 다 없애기
	public bool dontMove;//이거 켜지면 몬스터들 3초 동안 못움직임

    void Update()
    {
		if (dontMove)
		{
			countMove += Time.deltaTime;
			if (countMove >= 3)
			{
				dontMove = false;
				countMove = 0;
			}
		}
		countTime += Time.deltaTime;
		if (countTime < 1) return;
		countTime = 0;
		number = Random.Range(1, 100 + 1);
		if (number > chance) return;
		Spawn_Cell();
    }
	public void Spawn_Cell()
	{
		Instantiate(bloodCell, new Vector3(Random.Range(-8f, 8), 5), Quaternion.identity);
	}

	public void Delete_Bullet()
	{
		for (int i = 0; i < enemyBulletList.Count; i++)
		{
			if (!enemyBulletList[i]) continue;
			Destroy(enemyBulletList[i]);
		}
	}
}
