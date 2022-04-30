using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerGoToNext : MonoBehaviour
{
	public GameObject blackWall;
	int hpPlus, hurtPlus, itemPlus;
	public bool isDead, isEnd;
    // Start is called before the first frame update
    void Start()
    {
		isEnd = true;
		if (FindObjectOfType<PlayerHP>().HP <= 0)
		{
			StartCoroutine(Destroy_Player());
			FindObjectOfType<PlayerHP>().HP = 0;
		}
		hpPlus = FindObjectOfType<PlayerHP>().HP * 20;
		if (FindObjectOfType<PlayerHurt>().hurt >= 100)
		{
			FindObjectOfType<PlayerHurt>().hurt = 100;
		}
		hurtPlus = (FindObjectOfType<PlayerHurt>().maxHurt - FindObjectOfType<PlayerHurt>().hurt) * 15;
		itemPlus = FindObjectOfType<Score>().itemCount * 150;
		GameObject.Find("MakeObject").GetComponent<CheatKey>().enabled = false;
		GameObject.Find("HP").GetComponent<PlayerHP>().enabled = false;
		GameObject.Find("PP").GetComponent<PlayerHurt>().enabled = false;
		GetComponent<MakeBullet>().enabled = false;
		GetComponent<MovePlayer>().enabled = false;
		GetComponent<Player>().enabled = false;
		GetComponent<SpriteRenderer>().enabled = true;
		GetComponent<SpriteRenderer>().color = Color.white;
		for (int i = 0; i < 6; i++)
		{
			GameObject.Find("Canvas").transform.GetChild(i).gameObject.SetActive(false);
		}
		if (isDead)
		{
			blackWall.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
			blackWall.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
			blackWall.transform.GetChild(7).GetChild(0).gameObject.SetActive(false);
			blackWall.transform.GetChild(7).GetChild(1).gameObject.SetActive(true);
		}
		else
		{
			blackWall.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
			blackWall.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
			blackWall.transform.GetChild(7).GetChild(0).gameObject.SetActive(true);
			blackWall.transform.GetChild(7).GetChild(1).gameObject.SetActive(false);
		}

		if (Stage.stage >= 1)
		{
			blackWall.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
			blackWall.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
			blackWall.transform.GetChild(7).GetChild(0).gameObject.SetActive(false);
			blackWall.transform.GetChild(7).GetChild(1).gameObject.SetActive(true);
		}

		blackWall.transform.GetChild(1).GetComponent<Text>().text = "HP 보너스 : " + hpPlus;
		blackWall.transform.GetChild(2).GetComponent<Text>().text = "PP 보너스 : " + hurtPlus;
		blackWall.transform.GetChild(3).GetComponent<Text>().text = "아이템 보너스 : " + itemPlus;
		Score.score += hpPlus + hurtPlus + itemPlus;
		blackWall.transform.GetChild(4).GetComponent<Text>().text = "총합 : " + Score.score;
		blackWall.SetActive(true);
    }

	public void Move_To_End()
	{
		SceneManager.LoadScene("End");
	}
    public void Start_To_Move()
	{
		StartCoroutine(Move());
	}
    IEnumerator Move()
    {
		float countTime = 0;
		while (true)
		{
			countTime += Time.deltaTime;
			transform.Translate(Vector3.up * 8 * Time.deltaTime);
			if (transform.position.y >= 6)
			{
				Stage.stage++;
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			yield return null;
		}
    }

	IEnumerator Destroy_Player()
	{
		while (true)
		{
			GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
			yield return null;
		}
	}
}
