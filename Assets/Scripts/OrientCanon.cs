using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientCanon : MonoBehaviour
{
    public Camera mainCamera;
    public Transform myTransform;
    public Transform Crosshair;

    // Update is called once per frame
    void Update()
    {
        //transform mouse position in 3D world position 
        Vector3 WorldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-mainCamera.transform.position.z));
        //position the crosshair in the 3D world
        Crosshair.position = WorldMousePosition;
        //orient the canon toward the crosshair
        Vector3 toTargetVector = WorldMousePosition - myTransform.position;
        float zRotation = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
        myTransform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
    }
}
