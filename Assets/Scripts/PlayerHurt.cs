using UnityEngine;
using UnityEngine.UI;

public class PlayerHurt : MonoBehaviour
{
	[Range(0, 100)] public int hurt;
	private int maxHurt;
	public bool downHurt;

    void Awake()
    {
		if (Stage.stage == 0)
		{
			hurt = 10;
		}
		if(Stage.stage == 1)
		{
			hurt = 30;
		}
		maxHurt = 100;
		downHurt = false;
    }

	private void Update()
	{
		GetComponent<Text>().text = "Hurt : " + hurt + "/" + maxHurt;

		if (downHurt)
		{
			hurt -= 30;
			if (hurt < 0)
			{
				hurt = 0;
			}
			downHurt = false;
		}
		if (hurt >= maxHurt)
		{
			FindObjectOfType<Stage>().Goto_End();
		}
	}
}
