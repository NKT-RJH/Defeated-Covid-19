using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public int item;

	void Start()
	{
		item = Random.Range(1, 4 + 1);
		switch (item)
		{
			case 1:
				GetComponent<SpriteRenderer>().color = Color.green;
				break;
			case 2:
				GetComponent<SpriteRenderer>().color = Color.blue;
				break;
			case 3:
				GetComponent<SpriteRenderer>().color = Color.red;
				break;
			case 4:
				GetComponent<SpriteRenderer>().color = Color.grey;
				break;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag != "Player") return;
	
		WeaponLevel weaponLevel = FindObjectOfType<WeaponLevel>();
		Player player = FindObjectOfType<Player>();
		PlayerHP playerHP = FindObjectOfType<PlayerHP>();
		PlayerHurt hurtGauge = FindObjectOfType<PlayerHurt>();

		switch (item)
		{
			case 1:
				weaponLevel.bulletLevel++;
				GameObject.Find("WeaponLevel").transform.GetChild(weaponLevel.bulletLevel - 1).gameObject.SetActive(true);
				break;
			case 2:
				player.isCantBreak = true;
				break;
			case 3:
				playerHP.heal = true;
				break;
			case 4:
				hurtGauge.downHurt = true;
				break;
		}
		Destroy(gameObject);
	}
}