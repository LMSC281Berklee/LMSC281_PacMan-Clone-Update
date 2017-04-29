//LMSC PRIN KEERASUNTONPONG 
//Camera Script from Java to C# Conversion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Smooth Follow")]
public class SmoothFollow : MonoBehaviour {

    public Transform target;
    public float distance = 5.0f;
    public float height = 40.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    private float wantedRotationAngle = 0f;
    private float wantedHeight = 0f;
    private float currentRotationAngle = 0f;
    private float currentHeight;
    private Quaternion currentRotation = new Quaternion(); 

    void LateUpdate()
    {
        if (!target)
        {
            return; 
        }

        wantedRotationAngle = target.eulerAngles.y;
        wantedHeight = target.position.y + height;

        currentRotationAngle = transform.eulerAngles.y;
        currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        //transform.position.y = currentHeight;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(target);


    }
}
