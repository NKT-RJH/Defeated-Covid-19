using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	[HideInInspector] public int score;

	private void Awake()
	{
		score = 0;
	}

	// Update is called once per frame
	void Update()
    {
		GetComponent<Text>().text = "Score : " + score;
    }
}
