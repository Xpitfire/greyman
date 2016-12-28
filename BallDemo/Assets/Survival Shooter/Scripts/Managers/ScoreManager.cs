using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    public const int MaxScore = 20;
    
    Text text;
    
    void Awake()
    {
        text = GetComponent<Text>();
        Score = 0;
    }


    void Update()
    {
        text.text = "Found: " + Score + "/" + MaxScore;
    }
}
