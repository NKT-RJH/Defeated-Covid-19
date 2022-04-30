using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponLevel : MonoBehaviour
{
	[Range(0, 4)] public static int level;
    void Update()
    {
		if (level >= 5) level = 4;
		transform.GetChild(0).GetComponent<Text>().text = " : " + (level + 1);
    }
}
