using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
	public float speed = 3;
    
    void Update()
    {
		transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }
	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
