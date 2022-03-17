using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	[SerializeField] private float speed;
	
    void Update()
    {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 position = transform.position;

		if (position.x < 3.68 && position.x > -8.46)
		{
			position.x += horizontal * Time.deltaTime * speed;
		}
		else
		{
			if (position.x > 0)
			{
				position.x = 3.679f;
			}
			else
			{
				position.x = -8.459f;
			}
			//position.x = position.x / Mathf.Abs(position.x) * 7.99f;
		}

		if (position.y < 4.54 && position.y > -4.54)
		{
			position.y += vertical * Time.deltaTime * speed;
		}
		else
		{
			if(position.y > 0)
			{
				position.y = 4.539f;
			}
			else
			{
				position.y = -4.539f;
			}
			//position.y = position.y / Mathf.Abs(position.y) * 4.539f;
		}
		transform.position = position;
	}
}