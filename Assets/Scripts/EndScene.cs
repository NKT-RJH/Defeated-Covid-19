using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
	public GameObject rank;

	public void Get_Num(Text text)
	{
		RankValue rankValue = new RankValue();
		rankValue.name = text.text;
		rankValue.score = Score.score;
		StartScene.rankList.Add(rankValue);

		StartScene.rankList.OrderByDescending(x => x.score); ;

		for (int i = 0; i < StartScene.rankList.Count; i++)
		{
			rank.transform.GetChild(2).GetChild(StartScene.rankList.Count - i - 1).GetChild(0).GetComponent<Text>().text = StartScene.rankList[i].name;
			rank.transform.GetChild(2).GetChild(StartScene.rankList.Count - i - 1).GetChild(1).GetComponent<Text>().text = StartScene.rankList[i].score.ToString();
		}

		rank.SetActive(true);
	}

	public void Quit_Rank()
	{
		SceneManager.LoadScene("Start");
	}
}
