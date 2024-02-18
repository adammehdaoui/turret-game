using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public GameManager gameManager;
    public int Life = 3;
    public Text LifeValue;
    
    private void Start()
    {
        LifeValue.text = $"{Life}";
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the colliding object is an enemy && and the game isn't over
        if (collision.gameObject.CompareTag("Enemy") && gameManager.isPlaying)
        {
            //kill the enemy
            collision.gameObject.GetComponent<EnemyLife>().Death();
            //Reduce life
            Life--;
            
			//Update the life value
            LifeValue.text = $"{Life}";
            
            if (Life <= 0)
            {
                //Kill the player
                Death();
            }
        }
    }

    void Death()
    {
        //stop the game
        gameManager.PlayerIsDeadStopGame();
        //destroy the player object
        Destroy(gameObject);
    }
}
