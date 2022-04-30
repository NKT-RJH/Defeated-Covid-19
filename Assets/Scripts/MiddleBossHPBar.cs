using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiddleBossHPBar : MonoBehaviour
{
	void Update()
	{
		if (!FindObjectOfType<MiddleBoss>())
		{
			gameObject.SetActive(false);
			enabled = false;
			Destroy(gameObject);
			return;
		}
		transform.GetChild(0).GetComponent<Image>().fillAmount = FindObjectOfType<MiddleBoss>().GetComponent<Enemy>().hp / (float)FindObjectOfType<MiddleBoss>().GetComponent<Enemy>().maxhp;
		transform.GetChild(1).GetComponent<Text>().text = FindObjectOfType<MiddleBoss>().GetComponent<Enemy>().hp + " / " + FindObjectOfType<MiddleBoss>().GetComponent<Enemy>().maxhp;
	}
}
