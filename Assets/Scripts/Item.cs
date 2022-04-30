using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	[Range(1,6)]public int item;
	public GameObject boom;
	public int speed = 1;
	private void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag != "Player") return;
		FindObjectOfType<Score>().itemCount++;
		switch(item)
		{
			case 1:
				WeaponLevel.level++;
				break;
			case 2:
				if (FindObjectOfType<Player>().isCantBreak && SaveItems.itemList[0] < 3)
				{
					SaveItems.itemList[0]++;
					break;
				}
				FindObjectOfType<Player>().isCantBreak = true;
				break;
			case 3:
				if (FindObjectOfType<PlayerHP>().HP >= FindObjectOfType<PlayerHP>().maxHP && SaveItems.itemList[1] < 3)
				{
					SaveItems.itemList[1]++;
					break;
				}
				FindObjectOfType<PlayerHP>().heal = true;
				break;
			case 4:
				if (FindObjectOfType<PlayerHurt>().hurt <= 0 && SaveItems.itemList[0] < 3 && SaveItems.itemList[2] < 3)
				{
					SaveItems.itemList[2]++;
					break;
				}
				FindObjectOfType<PlayerHurt>().downHurt = true;
				break;
			case 5:
				FindObjectOfType<MakeBloodCell>().Delete_Bullet();
				Instantiate(boom, Vector3.zero, Quaternion.identity);
				break;
			case 6:
				if (FindObjectOfType<MakeBloodCell>().dontMove && SaveItems.itemList[3] < 3)
				{
					SaveItems.itemList[3]++;
					break;
				}
				FindObjectOfType<MakeBloodCell>().dontMove = true;
				break;
		}
		Destroy(gameObject);
	}

	IEnumerator Dont_Move()
	{
		FindObjectOfType<MakeBloodCell>().dontMove = true;
		yield return new WaitForSeconds(3);
		FindObjectOfType<MakeBloodCell>().dontMove = false;
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
