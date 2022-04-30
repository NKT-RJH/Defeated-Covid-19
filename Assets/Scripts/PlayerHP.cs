using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
	[Range(0, 100)] public int HP, maxHP;
	public bool heal;
    // Start is called before the first frame update
    void Start()
    {
		HP = 100;
		maxHP = HP;
		heal = false;
    }

    // Update is called once per frame
    void Update()
    {
		transform.GetChild(0).GetComponent<Image>().fillAmount = HP / (float)maxHP;
		transform.GetChild(1).GetComponent<Text>().text = HP + " / " + maxHP;
		if (heal)
		{
			HP += 30;
			heal = false;
		}
		if (HP > maxHP)
			HP = maxHP;
		if (HP <= 0)
			FindObjectOfType<Stage>().Load_ScoreBox();
	}
}
