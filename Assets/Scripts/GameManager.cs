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


    public GameObject Message; //game object used to wrap the game status with background
    
    public Text GameStatus; //text used to show the game status to player

    public void Start()
    {
        Message.SetActive(false);
        // Set the gameobject to inactive to hide the message and let the player play
    }
    
    public void PlayerIsDeadStopGame()
    {
        isPlaying = false;
        Message.SetActive(true);
        GameStatus.text = "YOU LOSE!";
        GameStatus.color = Color.red;
        // Set the gameobject to active to display the lose message
    }

    public void PlayerWin()
    {
        isPlaying = false;
        Message.SetActive(true);
        GameStatus.text = "YOU WIN!";
        GameStatus.color = Color.red;
        // Set the gameobject to active to display the win message
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying && RemainingTime > 0)
        {
            //reduce reamining time at each frame
            RemainingTime -= Time.deltaTime;
            timeValue.text = $"{RemainingTime:0.00}";

            //if the play time is over
            if (RemainingTime <= 0 && isPlaying)
            {
                PlayerWin();
            }
        }
    }
}
