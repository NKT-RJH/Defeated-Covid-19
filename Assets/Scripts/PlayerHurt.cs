using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHurt : MonoBehaviour
{
	[Range(0, 100)] public int hurt;
	private int maxHurt;
	public bool downHurt;

    void Awake()
    {
		hurt = 10;
		maxHurt = 100;
		downHurt = false;
    }

	private void Update()
	{
		GetComponent<Text>().text = "Hurt : " + hurt + "/" + maxHurt;

		if (downHurt)
		{
			hurt -= 30;
			if (hurt < 0)
			{
				hurt = 0;
			}
			downHurt = false;
		}
		if (hurt == maxHurt)
		{
			SceneManager.LoadScene("End");
		}
	}
}
