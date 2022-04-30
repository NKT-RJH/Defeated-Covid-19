using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveItems : MonoBehaviour
{
	public static int[] itemList = new int[4];

    void Update()
    {
		for (int i = 0; i < 4; i++)
		{
			transform.GetChild(i).GetComponent<Text>().text = itemList[i] + " / 3";
		}
		if (Input.GetKeyDown(KeyCode.U) && itemList[0] > 0)
		{
			FindObjectOfType<Player>().isCantBreak = true;
			itemList[0]--;
		}
		if (Input.GetKeyDown(KeyCode.I) && itemList[1] > 0)
		{
			FindObjectOfType<PlayerHP>().heal = true;
			itemList[1]--;
		}
		if (Input.GetKeyDown(KeyCode.O) && itemList[2] > 0)
		{
			FindObjectOfType<PlayerHurt>().downHurt = true;
			itemList[2]--;
		}
		if (Input.GetKeyDown(KeyCode.K) && itemList[3] > 0)
		{
			FindObjectOfType<MakeBloodCell>().dontMove = true;
			itemList[3]--;
		}
	}
}
