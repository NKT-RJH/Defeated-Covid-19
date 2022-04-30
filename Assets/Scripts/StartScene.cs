using System.Collections;
using System.Collections.Generic;
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
	public GameObject rank, storyText, help, helpView, helpLeft, helpRight;
	public int helpScrollNum;
	public static List<RankValue> rankList = new List<RankValue>();
	Coroutine coroutine;
	private void Awake()
	{
		rankList.Sort((a, b) => a.score.CompareTo(b.score));
		int num = 5;
		if (rankList.Count < num)
			num = rankList.Count;
		for (int i = 0; i < num; i++)
		{
			rank.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = rankList[rankList.Count - i - 1].name;
			rank.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = rankList[rankList.Count - i - 1].score.ToString();
		}
	}

	public void Start_Game()
	{
		help.SetActive(false);
		coroutine = StartCoroutine(Typing_Story());
	}
	public void Rank()
	{
		help.SetActive(false);
		rank.SetActive(true);
	}
	public void Quit_Rank()
	{
		help.SetActive(true);
		rank.SetActive(false);
	}
	public void Quit_Game()
	{
		Application.Quit(0);
	}
	IEnumerator Typing_Story()
	{
		storyText.SetActive(true);
		
		storyText.transform.GetChild(0).gameObject.SetActive(true);
		yield return new WaitForSeconds(1);
		for (int i = 1; i < 7; i++)
		{
			storyText.transform.GetChild(i).gameObject.SetActive(true);
			yield return new WaitForSeconds(0.3f);
		}
		yield return new WaitForSeconds(0.3f);
		storyText.transform.GetChild(7).gameObject.SetActive(true);
		for (int i = 8; i < 17; i++)
		{
			storyText.transform.GetChild(i).gameObject.SetActive(true);
		}
		for (int i = 8; i < 17; i++)
		{
			storyText.transform.GetChild(i).gameObject.SetActive(false);
			yield return new WaitForSeconds(1.5f);
		}
		yield return new WaitForSeconds(3);

		Stage.stage = 0;
		Score.score = 0;
		WeaponLevel.level = 0;
		for (int i = 0; i < SaveItems.itemList.Length; i++)
		{
			SaveItems.itemList[i] = 0;
		}
		SceneManager.LoadScene("Fight");
	}
	public void Skip_Story()
	{
		StopCoroutine(coroutine);
		Stage.stage = 0;
		Score.score = 0;
		WeaponLevel.level = 0;
		for (int i = 0; i < SaveItems.itemList.Length; i++)
		{
			SaveItems.itemList[i] = 0;
		}
		SceneManager.LoadScene("Fight");
	}

	public void Help()
	{
		helpView.SetActive(true);
	}
	public void Quit_Help()
	{
		helpView.SetActive(false);
	}
	public void Help_Left()
	{
		if (helpScrollNum - 1 == 0)
		{
			helpLeft.SetActive(false);
		}
		else
		{
			helpLeft.SetActive(true);
			helpRight.SetActive(true);
		}
		helpView.transform.GetChild(helpScrollNum).gameObject.SetActive(false);
		helpScrollNum--;
		helpView.transform.GetChild(helpScrollNum).gameObject.SetActive(true);
	}
	public void Help_Right()
	{
		if (helpScrollNum + 1 == 6)
		{
			helpRight.SetActive(false);
		}
		else
		{
			helpLeft.SetActive(true);
			helpRight.SetActive(true);
		}
		helpView.transform.GetChild(helpScrollNum).gameObject.SetActive(false);
		helpScrollNum++;
		helpView.transform.GetChild(helpScrollNum).gameObject.SetActive(true);
	}
}
