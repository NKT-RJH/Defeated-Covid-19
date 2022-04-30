using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoToStart : MonoBehaviour
{
	public Vector3 start, end;
	public GameObject startText;
	float countTime,tF;
	List<GameObject> gList = new List<GameObject>();

	void Start()
	{
		start = transform.position;
		end = new Vector3(start.x, -2, start.z);
		for (int i = 0; i < 6; i++)
		{
			gList.Add(GameObject.Find("Canvas").transform.GetChild(i).gameObject);
		}
		for (int i = 0; i < gList.Count; i++)
		{
			gList[i].SetActive(false);
		}
		GameObject.Find("MakeObject").GetComponent<CheatKey>().enabled = false;
		GameObject.Find("MakeObject").GetComponent<MakeEnemy>().enabled = false;
		GameObject.Find("MakeRed").GetComponent<MakeBloodCell>().enabled = false;
		GameObject.Find("MakeWhite").GetComponent<MakeBloodCell>().enabled = false;
		GetComponent<MovePlayer>().enabled = false;
		GetComponent<Player>().enabled = false;
		GetComponent<MakeBullet>().enabled = false;
		Time.timeScale = 4;
	}

	void Update()
	{
		countTime += Time.deltaTime;
		transform.position = Vector3.Lerp(start, end, countTime / 4);
		if (Time.timeScale > 1)
		{
			Time.timeScale -= 0.005f;
		}
		if (transform.position.y >= -2)
		{
			Time.timeScale = 1;
			StartCoroutine(Visible_Message());
			for (int i = 0; i < gList.Count; i++)
			{
				gList[i].SetActive(true);
			}
			GameObject.Find("MakeObject").GetComponent<CheatKey>().enabled = true;
			GameObject.Find("MakeObject").GetComponent<MakeEnemy>().enabled = true;
			GameObject.Find("MakeRed").GetComponent<MakeBloodCell>().enabled = true;
			GameObject.Find("MakeWhite").GetComponent<MakeBloodCell>().enabled = true;
			GetComponent<MovePlayer>().enabled = true;
			GetComponent<Player>().enabled = true;
			GetComponent<MakeBullet>().enabled = true;
			FindObjectOfType<RepeatBackground>().speed = 5;
			FindObjectOfType<RepeatBackground>().transform.position = new Vector3(0, tF);
			enabled = false;
		}
	}
	IEnumerator Visible_Message()
	{
		startText.SetActive(true);
		yield return new WaitForSeconds(1);
		startText.SetActive(false);
	}
}
