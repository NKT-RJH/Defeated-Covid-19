using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
	bool cheking;
	public float speed = 2;
	public GameObject[] item = new GameObject[6];
    
    void Update()
    {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		bool i = false;
		if (collision.tag == "Bullet" || collision.tag == "Player") i = true;
		if (!i) return;
		if (collision.tag == "Bullet")
		{
			Destroy(collision.gameObject);
		}
		Instantiate(item[Random.Range(0, 6)], transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
