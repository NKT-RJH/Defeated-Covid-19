using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    void Update()
    {
		Camera.main.WorldToScreenPoint(new Vector3(FindObjectOfType<Boss>().transform.position.x, FindObjectOfType<Boss>().transform.position.y - 1, FindObjectOfType<Boss>().transform.position.z));
		GetComponent<Text>().text = "HP : " + FindObjectOfType<Boss>().GetComponent<Enemy>().hp + "/" + FindObjectOfType<Boss>().GetComponent<Enemy>().maxhp;
	}
}
