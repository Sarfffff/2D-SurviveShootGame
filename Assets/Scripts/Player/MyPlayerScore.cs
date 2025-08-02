using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MyPlayerScore : MonoBehaviour
{
    public static int Scores = 0; 
    public Text ScoreText;
    void Update()
    {
        ScoreText.text = $"Scores :{Scores}";//实时更新
    }
}
