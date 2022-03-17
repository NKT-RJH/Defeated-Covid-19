using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
	[Range(0, 100)]
	public int HP;

	private int maxHP;
	public bool heal;


    void Awake()
    {
		HP = 100;
		maxHP = 100;
		heal = false;
    }

    void Update()
    {
		GetComponent<Text>().text = "HP : " + HP + "/" + maxHP;
		if (heal)
		{
			HP += 30;
			if (HP > 100)
			{
				HP = 100;
			}
			heal = false;
		}
		if (HP == 0)
		{
			//����� ������ ȿ�� �߻� 1�� ����
			SceneManager.LoadScene("End");
		}
	}
}
