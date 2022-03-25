using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public struct RankValue
{
	public string name;
	public int score;
}

public class StartScene : MonoBehaviour
{
	public static List<RankValue> rankList = new List<RankValue>();
	public GameObject rank, storyText;
	public string[] story = new string[2];

	private void Start()
	{
		rankList.OrderByDescending(x => x.score);

		for (int i = 0; i < rankList.Count; i++)
		{
			rank.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Text>().text = rankList[i].name;
			rank.transform.GetChild(2).GetChild(i).GetChild(1).GetComponent<Text>().text = rankList[i].score.ToString();
		}
	}

	public void Game_Start()
	{
		StartCoroutine(Typing_Story());
	}

	public void Rank()
	{
		rank.SetActive(true);
	}

	public void Quit_Rank()
	{
		rank.SetActive(false);
	}

	public void Game_End()
	{
		Application.Quit();
	}

	public IEnumerator Typing_Story()
	{
		storyText.SetActive(true);

		Text text = storyText.transform.GetChild(0).GetComponent<Text>();
		text.text = "";
		
		text.text = story[0];
		yield return new WaitForSeconds(5);
		text.text = story[1];
		yield return new WaitForSeconds(2);
		
		Stage.stage = 0;
		Score.score = 0;
		WeaponLevel.bulletLevel = 0;
		SceneManager.LoadScene("Fight");
	}
}
