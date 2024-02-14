using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true; //set to false when player met win or loss conditions

    public float RemainingTime = 30f; //remaining time before the player win the game
    public Text timeValue; //text used to show remaining time to player

    public int score = 0; //points
    public Text scoreValue; //text used to show score to player

    public Text EndGameText; //text used to show the endgame message

    public void PlayerIsDeadStopGame()
    {
        isPlaying = false;
    }

    public void PlayerWin()
    {
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying && RemainingTime > 0)
        {
            //reduce reamining time at each frame
            RemainingTime -= Time.deltaTime;

            //if the play time is over
            if (RemainingTime <= 0 && isPlaying)
            {
                PlayerWin();
            }
        }
    }
}
