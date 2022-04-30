using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
	public static int stage;

	void Update()
	{
		GetComponent<Text>().text = "Stage : " + (stage + 1);
	}

	public void Next_Stage()
	{
		stage++;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void Load_ScoreBox()
	{
		StartCoroutine(wait());
	}
	IEnumerator wait()
	{
		yield return new WaitForSeconds(1);
		FindObjectOfType<PlayerGoToNext>().enabled = true;
	}
}
