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
			blackWall.SetActive(true); //ġƮŰ ����� ����ȭ���̶� ��ȭ�� �����!!!
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