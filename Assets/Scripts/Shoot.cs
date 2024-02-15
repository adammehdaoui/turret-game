using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform CanonEnd;
    public float bulletSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        //ih the player press mouse button number 0
        if(Input.GetMouseButtonDown(0))
        {
            BulletShot();
        }
    }

    void BulletShot()
    {
        //create the bullet
        GameObject bullet = Instantiate(BulletPrefab,CanonEnd.position,CanonEnd.rotation);
        //add the force to move the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
        rb.AddRelativeForce(new Vector2(bulletSpeed, 0f),ForceMode2D.Impulse);
        rb.gravityScale = 0f;
    }
}
