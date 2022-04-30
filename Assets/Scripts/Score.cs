using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public static int score;
	public int itemCount; // 나중에 스테이지 끝나고 점수 계산한거 보여주는 것 만들기!
    
    void Update()
    {
		GetComponent<Text>().text = "Score : " + score;
    }
}
