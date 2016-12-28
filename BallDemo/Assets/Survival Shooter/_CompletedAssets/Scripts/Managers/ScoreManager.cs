﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's Score.


        Text text;                      // Reference to the Text component.


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the Score.
            score = 0;
        }


        void Update ()
        {
            // Set the displayed text to be the word "Score" followed by the Score value.
            text.text = "Score: " + score;
        }
    }
}