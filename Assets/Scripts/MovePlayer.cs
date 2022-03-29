using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public float speed;
	
    void Update()
    {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		//Vector3 position = transform.position;

		transform.position += new Vector3(horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed);
		//position.x += horizontal * Time.deltaTime * speed;
		//position.y += vertical * Time.deltaTime * speed;

		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		if (pos.x > 1) pos.x = 1;
		if (pos.x < 0) pos.x = 0;
		if (pos.y > 1) pos.y = 1;
		if (pos.y < 0) pos.y = 0;

		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}
}