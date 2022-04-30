using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBullet : MonoBehaviour
{
	public int damage = 5;
	public GameObject bullet;
	float countTime;

    void Update()
    {
		countTime += Time.deltaTime;
		if (countTime < 0.1f) return;
		countTime = 0;
		if (Input.GetKey(KeyCode.J))
		{
			Vector3[] p = new Vector3[5];
			switch (WeaponLevel.level)
			{
				case 1:
					p[0].x = -0.2f;
					p[1].x = 0.2f;
					break;
				case 2:
					p[1].x = -0.1f;
					p[2].x = 0.1f;
					p[1].z = -10;
					p[2].z = 10;
					break;
				case 3:
					p[0].x = -0.1f;
					p[1].x = 0.1f;
					p[2].x = -0.1f;
					p[3].x = 0.1f;
					p[2].z = -10;
					p[3].z = 10;
					break;
				case 4:
					p[1].x = -0.1f;
					p[2].x = 0.1f;
					p[3].x = -0.1f;
					p[4].x = 0.1f;
					p[1].z = -10;
					p[2].z = 10;
					p[3].z = -15;
					p[4].z = 15;
					break;
			}
			for (int i = 0; i <= WeaponLevel.level; i++)
			{
				GameObject g = Instantiate(bullet, new Vector3(transform.position.x + p[i].x, transform.position.y + 0.5f), Quaternion.identity);
				g.GetComponent<Bullet>().power = 500 + WeaponLevel.level * 50;
				g.GetComponent<Bullet>().startAngle = new Vector2(p[i].z / 100f, 1);
			}
		}
	}
}
