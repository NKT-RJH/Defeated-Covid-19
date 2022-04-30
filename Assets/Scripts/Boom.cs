using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.localScale += new Vector3(Time.deltaTime * 30, Time.deltaTime * 30);
		if (transform.localScale.x >= 7.5f)
		{
			Destroy(gameObject);
		}
    }
}
