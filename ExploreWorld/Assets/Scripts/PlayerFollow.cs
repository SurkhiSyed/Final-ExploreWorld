//Syed Kaab Surkhi
//June 1, 2022
//Make Camera Follow Player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform cameraTarget;   //Create a target for the camera to be located at
    public float CamSpeed = 10.0f;  //Set Camera Speed
    public Vector3 dist; //Create a variable for distance
    public Transform lookTarget; //Create a target for the camera to look at
    public GameObject player; //Create a player variable

    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()  
    {
        Vector3 dPos = cameraTarget.position + dist; //Set dPos variable to match CameraTaget + dist
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, CamSpeed * Time.deltaTime); //Set sPos variable to match the Vector Position of the Camera
        transform.position = sPos; //Set the Camera's position to match sPos variable
        transform.LookAt(lookTarget); //Make Camera look at the LookTarget Variable
    }
}
