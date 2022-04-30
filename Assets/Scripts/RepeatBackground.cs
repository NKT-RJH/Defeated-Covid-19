using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
	public float speed, yValue;
	Vector2 startPos;
	float newPos;
    // Start is called before the first frame update
    void Start()
    {
		startPos = transform.position;   
    }

    void Update()
    {
		newPos = Mathf.Repeat(Time.time * speed, yValue);
		transform.position = startPos + Vector2.down * newPos;
    }
}
