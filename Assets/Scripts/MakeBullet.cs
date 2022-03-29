using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBullet : MonoBehaviour
{
	public GameObject bullet;
	public int damage;
	private float countTime;

	private void Awake()
	{
		damage = 5;
	}

	void Update()
    {
		countTime += Time.deltaTime;

		if (countTime < 0.1f) return;

		countTime -= 0.1f;
		
		Vector2 shootWhere = Vector2.zero;

		if (Input.GetKey(KeyCode.J))
		{
			Vector3[] startPath = new Vector3[5];
			int addSpeed = 0;
			//총알 레벨 만들기
			switch (WeaponLevel.bulletLevel)
			{
				case 0:
					startPath[0].x = transform.position.x;
					startPath[0].z = 0f;
					addSpeed = 500;
					break;
				case 1:
					startPath[0].x = transform.position.x - 0.2f;
					startPath[1].x = transform.position.x + 0.2f;
					startPath[0].z = 0f;
					startPath[1].z = 0f;
					addSpeed = 550;
					break;
				case 2:
					startPath[0].x = transform.position.x;
					startPath[1].x = transform.position.x - 0.1f;
					startPath[2].x = transform.position.x + 0.1f;
					startPath[0].z = 0f;
					startPath[1].z = -5f;
					startPath[2].z = 5f;
					addSpeed = 600;
					break;
				case 3:
					startPath[0].x = transform.position.x - 0.1f;
					startPath[1].x = transform.position.x + 0.1f;
					startPath[2].x = transform.position.x - 0.1f;
					startPath[3].x = transform.position.x + 0.1f;
					startPath[0].z = 0f;
					startPath[1].z = 0f;
					startPath[2].z = -10f;
					startPath[3].z = 10f;
					addSpeed = 650;
					break;
				case 4:
					startPath[0].x = transform.position.x;
					startPath[1].x = transform.position.x - 0.1f;
					startPath[2].x = transform.position.x + 0.1f;
					startPath[3].x = transform.position.x - 0.1f;
					startPath[4].x = transform.position.x + 0.1f;
					startPath[0].z = 0f;
					startPath[1].z = -7.5f;
					startPath[2].z = 7.5f;
					startPath[3].z = -15f;
					startPath[4].z = 15f;
					addSpeed = 700;
					break;
			}
			for (int i = 0; i <= WeaponLevel.bulletLevel; i++)
			{
				GameObject game2 = Instantiate(bullet, new Vector2(startPath[i].x, transform.position.y + 0.5f), Quaternion.identity);
				game2.GetComponent<Bullet>().startAngle = new Vector2(startPath[i].z / 100, 1);
				game2.GetComponent<Bullet>().power = addSpeed;
			}
		}
	}
}