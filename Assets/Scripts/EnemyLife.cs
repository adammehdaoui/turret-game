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
        //reduce life
        Life--;
        //if life is under 0
        if (Life <= 0)
        {
            //kill the enemy
            Death();
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
