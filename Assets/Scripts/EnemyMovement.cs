using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform myTransform;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        myTransform = transform;

        //look toward the player   
        Vector3 toTargetVector = -myTransform.position;
        float zRotation = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
        myTransform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
    }

    // Update is called once per frame
    void Update()
    {
        //move toward the player
        myTransform.position += myTransform.right * moveSpeed * Time.deltaTime;
    }
}
