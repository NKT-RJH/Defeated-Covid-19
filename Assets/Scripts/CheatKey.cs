using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatKey : MonoBehaviour
{
	public GameObject cheatKey;
	public int cheatMod;
	public bool editBox = false;
	bool stop;

	public List<GameObject> enemys = new List<GameObject>();

    void Update()
    {
		if (editBox) return;

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Stage.stage = -1;
			FindObjectOfType<Stage>().Next_Stage();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Stage.stage = 0;
			FindObjectOfType<Stage>().Next_Stage();//나중에 스테이지 다시 이동만 하기
		}

		if (Input.GetKeyDown(KeyCode.F1))
		{
			WeaponLevel.bulletLevel = 0;
		}
		if (Input.GetKeyDown(KeyCode.F2))
		{
			WeaponLevel.bulletLevel = 1;
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			WeaponLevel.bulletLevel = 2;
		}
		if (Input.GetKeyDown(KeyCode.F4))
		{
			WeaponLevel.bulletLevel = 3;
		}
		if (Input.GetKeyDown(KeyCode.F5))
		{
			WeaponLevel.bulletLevel = 4;
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			stop = false;
			StopCoroutine(On_Cant_Break());
			StartCoroutine(On_Cant_Break());
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			stop = true;
			FindObjectOfType<Player>().onCantBreak = false;
			FindObjectOfType<Player>().GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			Delete_All();
		}

		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			editBox = true;
			Time.timeScale = 0;
			cheatMod = 0;
			cheatKey.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			editBox = true;
			Time.timeScale = 0;
			cheatMod = 1;
			cheatKey.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			GameObject.Find("MakeRed").GetComponent<MakeBloodCell>().Spawn_Cell();
		}

		if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			GameObject.Find("MakeWhite").GetComponent<MakeBloodCell>().Spawn_Cell();
		}
	}

	IEnumerator On_Cant_Break()
	{
		while (true)
		{
			if (stop) break;

			FindObjectOfType<Player>().GetComponent<SpriteRenderer>().color = Color.blue;
			FindObjectOfType<Player>().onCantBreak = true;
			yield return null;
		}
	}

	void Delete_All()
	{
		for (int i = 0; i < enemys.Count; i++)
		{
			if (!enemys[i]) continue;
			enemys[i].GetComponent<Enemy>().hit = true;
			Destroy(enemys[i]);
			enemys[i].GetComponent<Enemy>().If_Boss();
		}
	}

	public void Get_Num(Text text)
	{
		cheatKey.SetActive(false);
		editBox = false;
		if (cheatMod == 0)
		{
			if (int.Parse(text.text) <= 0)
			{
				FindObjectOfType<Stage>().Goto_End();
			}
			FindObjectOfType<PlayerHP>().HP = int.Parse(text.text);
		}
		if (cheatMod == 1)
		{
			if (int.Parse(text.text) >= 100)
			{
				FindObjectOfType<Stage>().Goto_End();
			}
			FindObjectOfType<PlayerHurt>().hurt = int.Parse(text.text);
		}
		text.text = "";
		Time.timeScale = 1;
	}
}
