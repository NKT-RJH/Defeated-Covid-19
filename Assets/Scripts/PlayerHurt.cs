using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHurt : MonoBehaviour
{
	[Range(0, 100)] public int hurt, maxHurt;
	public bool downHurt;
	// Start is called before the first frame update
	void Start()
	{
		if (Stage.stage == 0)
			hurt = 10;
		if (Stage.stage == 1)
			hurt = 30;
		maxHurt = 100;
		downHurt = false;
	}

	// Update is called once per frame
	void Update()
	{
		transform.GetChild(0).GetComponent<Image>().fillAmount = hurt / (float)maxHurt;
		transform.GetChild(1).GetComponent<Text>().text = hurt + " / " + maxHurt;
		if (downHurt)
		{
			hurt -= 30;
			downHurt = false;
		}
		if (hurt < 0)
			hurt = 0;
		if (hurt >= maxHurt)
			FindObjectOfType<Stage>().Load_ScoreBox();
	}
}
