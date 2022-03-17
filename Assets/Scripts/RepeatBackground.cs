using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float YValue;

	private Vector2 startPos;
	private float newPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		newPos = Mathf.Repeat(Time.time * speed, YValue);
		transform.position = startPos + Vector2.down * newPos;
    }
}
