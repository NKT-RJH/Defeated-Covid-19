using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
	public float speed;
	Transform playerTransform;
	Vector3 goal;
    
    void Start()
    {
		speed = FindObjectOfType<MakeEnemy>().speedList[GetComponent<Enemy>().enemyNumber - 1];
		playerTransform = FindObjectOfType<Player>().gameObject.transform;
		goal = (playerTransform.position - transform.position) / 10;
    }

    void Update()
    {
		transform.Translate(goal * Time.deltaTime * speed);
    }
}
