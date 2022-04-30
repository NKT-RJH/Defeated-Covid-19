using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
	public GameObject rank,getNumber;
	private void Awake()
	{
		StartScene.rankList.Sort((a, b) => a.score.CompareTo(b.score));
		if (StartScene.rankList.Count < 5)
		{
			getNumber.SetActive(true);
			return;
		}
		else
		{
			if (Score.score > StartScene.rankList[4].score)
			{
				getNumber.SetActive(true);
				return;
			}
		}
		rank.SetActive(true);
	}
	public void Get_Num(Text text)
	{
		RankValue r = new RankValue();
		r.name = text.text;
		r.score = Score.score;
		StartScene.rankList.Add(r);
		StartScene.rankList.Sort((a, b) => a.score.CompareTo(b.score));
		int num = 5;
		if (StartScene.rankList.Count < num)
			num = StartScene.rankList.Count;
		for (int i = 0; i < num; i++)
		{
			rank.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = StartScene.rankList[StartScene.rankList.Count - i - 1].name;
			rank.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = StartScene.rankList[StartScene.rankList.Count - i - 1].score.ToString();
		}
		getNumber.SetActive(false);
		rank.SetActive(true);
	}
	public void Goto_Start()
	{
		SceneManager.LoadScene("Start");
	}
}
