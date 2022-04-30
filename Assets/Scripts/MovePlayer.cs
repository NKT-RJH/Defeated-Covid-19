using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public float speed = 5;
    
    void Update()
    {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		transform.position += new Vector3(h * speed * Time.deltaTime, v * speed * Time.deltaTime);
		Vector3 p = Camera.main.WorldToViewportPoint(transform.position);
		if (p.x > 0.98) p.x = 0.98f;
		if (p.x < 0.02) p.x = 0.02f;
		if (p.y > 0.94) p.y = 0.94f;
		if (p.y < 0.06) p.y = 0.06f;
		transform.position = Camera.main.ViewportToWorldPoint(p);
    }
}
