using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLevel : MonoBehaviour
{
	[Range(1, 5)]
	public static int bulletLevel;

    void Update()
    {
		if (bulletLevel >= 5)
		{
			bulletLevel = 4;
		}
		for (int i = 0; i < 5; i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
		for (int i = 0; i <= bulletLevel; i++)
		{
			transform.GetChild(i).gameObject.SetActive(true);
		}
    }
}