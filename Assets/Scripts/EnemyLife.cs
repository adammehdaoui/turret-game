using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int Life = 1;
    public int Points = 1;
    public GameManager gameManager;

    public void DealDamages()
    {
        Life--;
        
        if (Life <= 0)
        {
            Death();
            
            if (gameObject.name == "YellowEnemy(Clone)")
            {
                gameManager.score++;
            }
            if (gameObject.name == "OrangeEnemy(Clone)")
            {
                gameManager.score+=2;
            }
            if (gameObject.name == "RedEnemy(Clone)")
            {
                gameManager.score+=3;
            }
            
            gameManager.scoreValue.text = $"{ gameManager.score}";
        }
    }

    //kill the enemy
    public void Death()
    {
        //destroy the enemy object
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), collision2d.gameObject.GetComponent<Collider2D>());
        }
    }
    
    private void OnTriggerEnter2D(Collider2D triggered)
    {
        if (triggered.gameObject.tag == "Bullet")
        {
            DealDamages();
            Destroy(triggered.gameObject);
        }
    }
}
