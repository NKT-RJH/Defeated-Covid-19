using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
	Vector3 goal;
    // Start is called before the first frame update
    void Start()
    {
		goal = (FindObjectOfType<Player>().transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
		if(!FindObjectOfType<MakeBloodCell>().dontMove)
			transform.Translate(goal * MakeEnemy.speedList[GetComponent<Enemy>().enemyNumber] * Time.deltaTime);
    }
}
