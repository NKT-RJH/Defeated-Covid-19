using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
	//[HideInInspector] public int stage = 1;
	 public int stage;

	private void Awake()
	{
		stage = 1;
	}

	private void Start()
	{
		GetComponent<Text>().text = "Stage " + stage;
	}

	private void Next_Stage()
	{
		MakeEnemy makeEnemy = FindObjectOfType<MakeEnemy>();
		for (int i = 0; i < makeEnemy.damageList.Length; i++)
		{
			makeEnemy.damageList[i] = makeEnemy.damageList[i] / 2;
			makeEnemy.hpList[i] *= 2;
		}
	}
}
