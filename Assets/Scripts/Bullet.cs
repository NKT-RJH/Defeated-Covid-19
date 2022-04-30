using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float power;
	public Vector2 startAngle;
	Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		rb.velocity = power * startAngle * Time.fixedDeltaTime;
    }
	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
