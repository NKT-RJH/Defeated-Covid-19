using UnityEngine;

public class MoveBoss : MonoBehaviour
{
	Vector3 start, goal;
	float countTime;
	public float speed;

	void Start()
    {
		speed = MakeEnemy.speedList[4];
        start = transform.position;
		goal = new Vector3(start.x, 2.5f, start.z);
    }

    // Update is called once per frame
    void Update()
    {
		countTime += Time.deltaTime;

		transform.position = Vector3.Lerp(start, goal, countTime * speed);

		if (transform.position.y == 2.5f)
		{
			GetComponent<Boss>().enabled = true;
			enabled = false;
		}
    }
}
