using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    void Update()
    {
		if (!FindObjectOfType<Boss>())
		{
			gameObject.SetActive(false);
			enabled = false;
			Destroy(gameObject);
			return;
		}
		transform.GetChild(0).GetComponent<Image>().fillAmount = FindObjectOfType<Boss>().GetComponent<Enemy>().hp / (float)FindObjectOfType<Boss>().GetComponent<Enemy>().maxhp;
		transform.GetChild(1).GetComponent<Text>().text = FindObjectOfType<Boss>().GetComponent<Enemy>().hp + " / " + FindObjectOfType<Boss>().GetComponent<Enemy>().maxhp;
	}
}
