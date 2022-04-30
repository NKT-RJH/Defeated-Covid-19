using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
	Vector3 start, end;
	float countTime;
    // Start is called before the first frame update
    void Start()
    {
		FindObjectOfType<MakeEnemy>().fighting = true;
		if (gameObject.tag == "Boss2")
		{
			if (Stage.stage == 0)
			{
				for (int i = 0; i < 6; i++)
				{
					transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 60 / 255f, 55 / 255f, 255 / 255f);
				}
			}
			if (Stage.stage == 1)
			{
				for (int i = 0; i < 6; i++)
				{
					transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.red;
				}
			}
		}
		start = transform.position;
		end = new Vector3(start.x, 3f, start.z);
    }

    // Update is called once per frame
    void Update()
    {
		if (!FindObjectOfType<MakeBloodCell>().dontMove)
		{
			countTime += Time.deltaTime;
			transform.position = Vector3.Lerp(start, end, countTime * MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber]);
		}
		if (transform.position.y <= 3)
		{
			if (GetComponent<Boss>())
				GetComponent<Boss>().enabled = true;
			if (GetComponent<MiddleBoss>())
				GetComponent<MiddleBoss>().enabled = true;
			enabled = false;
		}
    }
}
