using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScoreUpdate : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = "You found " + ScoreManager.Score + "/" + ScoreManager.MaxScore + "\nCollectables";
    }

}
