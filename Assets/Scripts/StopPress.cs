using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPress : MonoBehaviour
{
    public void Stop()
	{
		gameObject.SetActive(false);
	}
}
