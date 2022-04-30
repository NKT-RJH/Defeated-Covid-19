using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
	public GameObject snailDummy;
	void Update()
	{
		if (!FindObjectOfType<MakeBloodCell>().dontMove)
			transform.Translate(Vector3.down * MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber] * Time.deltaTime, Space.Self);
	}
	private void OnBecameInvisible()
	{
		if (!GetComponent<Enemy>().hit)
			Instantiate(snailDummy, new Vector3(Random.Range(-7f, 7), Random.Range(-3f, 3)), Quaternion.Euler(0, 0, Random.Range(0f, 360)));
		Destroy(gameObject);
	}
}
