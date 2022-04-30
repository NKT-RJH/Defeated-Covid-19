using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatKey : MonoBehaviour
{
	public GameObject cheatKey;
	bool editBox, stop;
	int cheatMod;
	public List<GameObject> enemyList = new List<GameObject>();
    
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
			FindObjectOfType<Stage>().Next_Stage();
		}

		if (Input.GetKeyDown(KeyCode.F1))
		{
			WeaponLevel.level = 0;
		}
		if (Input.GetKeyDown(KeyCode.F2))
		{
			WeaponLevel.level = 1;
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			WeaponLevel.level = 2;
		}
		if (Input.GetKeyDown(KeyCode.F4))
		{
			WeaponLevel.level = 3;
		}
		if (Input.GetKeyDown(KeyCode.F5))
		{
			WeaponLevel.level = 4;
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			stop = false;
			StartCoroutine(On_Cant_Break());
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			stop = true;
			FindObjectOfType<Player>().onCantBreak = false;
			FindObjectOfType<Player>().GetComponent<SpriteRenderer>().color = Color.white;
		}

		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			Delete_All();
		}

		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			editBox = true;
			cheatMod = 0;
			cheatKey.transform.GetChild(0).GetComponent<Text>().text = "HP 설정";
			Time.timeScale = 0;
			cheatKey.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			editBox = true;
			cheatMod = 1;
			cheatKey.transform.GetChild(0).GetComponent<Text>().text = "PP 설정";
			Time.timeScale = 0;
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
		while (!stop)
		{
			FindObjectOfType<Player>().onCantBreak = true;
			FindObjectOfType<Player>().GetComponent<SpriteRenderer>().color = Color.green;
			yield return null;
		}
	}

	void Delete_All()
	{
		for (int i = 0; i < enemyList.Count; i++)
		{
			if (!enemyList[i]) continue;
			enemyList[i].GetComponent<Enemy>().hit = true;
			Destroy(enemyList[i]);
		}
	}

	public void Quit_Get_Num()
	{
		editBox = false;
		cheatKey.SetActive(false);
		cheatKey.transform.GetChild(1).GetComponent<Text>().text = 0.ToString();
		Time.timeScale = 1;
	}
	public void Select_Get_Num()
	{
		editBox = false;
		cheatKey.SetActive(false);

		int n = int.Parse(cheatKey.transform.GetChild(1).GetComponent<Text>().text);
		if (cheatMod == 0)
		{
			if (n <= 0)
				FindObjectOfType<Stage>().Load_ScoreBox();
			FindObjectOfType<PlayerHP>().HP = n;
		}
		if (cheatMod == 1)
		{
			if (n >= 100)
				FindObjectOfType<Stage>().Load_ScoreBox();
			FindObjectOfType<PlayerHurt>().hurt = n;
		}
		cheatKey.transform.GetChild(1).GetComponent<Text>().text = 0.ToString();
		Time.timeScale = 1;
	}
	public void Up_Num()
	{
		int n = int.Parse(cheatKey.transform.GetChild(1).GetComponent<Text>().text);
		if (n < 100)
		{
			cheatKey.transform.GetChild(1).GetComponent<Text>().text = (n + 1).ToString();
		}
	}
	public void Down_Num()
	{
		int n = int.Parse(cheatKey.transform.GetChild(1).GetComponent<Text>().text);
		if (n > 0)
		{
			cheatKey.transform.GetChild(1).GetComponent<Text>().text = (n - 1).ToString();
		}
	}
}
