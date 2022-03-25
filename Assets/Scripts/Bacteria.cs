using UnityEngine;

public class Bacteria : MonoBehaviour
{
	public float speed;
	Transform playerTransform;
	Vector3 goal;
    
    void Start()
    {
		speed = MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber - 1];
		playerTransform = FindObjectOfType<Player>().gameObject.transform;
		goal = (playerTransform.position - transform.position).normalized;
    }

    void Update()
    {
		transform.Translate(goal * Time.deltaTime * speed);
    }
}
