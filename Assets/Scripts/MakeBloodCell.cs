using UnityEngine;

public class MakeBloodCell : MonoBehaviour
{
	public GameObject bloodCell;
	float countTime;
	int number;
	public int chance;

    void Update()
    {
		countTime += Time.deltaTime;

		if (countTime < 1) return;

		countTime = 0;
		number = Random.Range(1, 100 + 1);

		if (number > chance) return;

		Spawn_Cell();
    }

	public void Spawn_Cell()
	{
		float path = Random.Range(-8f, 3f);
		Instantiate(bloodCell, new Vector3(path, 5, 0), Quaternion.identity);
	}
}