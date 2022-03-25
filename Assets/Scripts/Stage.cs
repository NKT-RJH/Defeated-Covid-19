using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
	public GameObject blackWall;
	public static int stage;

	private void Update()
	{
		GetComponent<Text>().text = "Stage " + (stage + 1);
	}

	public void End_Stage()
	{
		Time.timeScale = 0;

		if (stage >= 1)
		{
			Goto_End();
		}
		else
		{
			blackWall.SetActive(true); //치트키 만들고 시작화면이랑 끝화면 만들기!!!
		}
	}

	public void Next_Stage()
	{
		stage++;
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Goto_End()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("End");
	}
}