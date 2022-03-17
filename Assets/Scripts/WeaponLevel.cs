using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLevel : MonoBehaviour
{
	[Range(1, 5)]
	public int bulletLevel;
	
	private void Awake()
	{
		bulletLevel = 1;
	}

    void Update()
    {
		for (int i = 0; i < bulletLevel; i++)
		{
			transform.GetChild(i).gameObject.SetActive(true);
		}
    }
}