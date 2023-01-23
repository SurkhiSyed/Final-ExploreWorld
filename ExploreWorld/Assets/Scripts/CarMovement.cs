//Syed Kaab Surkhi
//June 1, 2022
//Control Player Movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MathClassCS
{

    public class CarMovement : MonoBehaviour
    {
        //Create a variable and option to input Speed
        public float speed = 5.0f;
        //Create a veriable that stores turning Speed
        public float turnspeed;
        //Create a variable to control horizontal movement (Sideways)
        public float MoveSidewaysInput;
        //Create a variable to control vertical movement (Front and Back)
        public float ForwardInput;
        //Create a variable for the Front Right Wheel Turn
        [SerializeField] WheelCollider frontRight; //Create a serialized WheelCollider for Front Right wheel
        [SerializeField] WheelCollider frontLeft; //Create a serialized WheelCollider for Front Left wheel
        [SerializeField] WheelCollider backRight; //Create a serialized WheelCollider for Back Right wheel
        [SerializeField] WheelCollider backLeft; //Create a serialized WheelCollider for Back Left wheel

        [SerializeField] Transform frontRightTransform; //Create a serialized Trandform variable for Front Right Wheel
        [SerializeField] Transform frontLeftTransform; //Create a serialized Trandform variable for Front Left Wheel
        [SerializeField] Transform backRightTransform; //Create a serialized Trandform variable for Back Right Wheel
        [SerializeField] Transform backLeftTransform; //Create a serialized Trandform variable for Back Left Wheel

        public float acceleration = 500f; //Create a public variable named acceleration and set it to 500f
        public float breakingForce = 300f; //Create a public variable named breakingForce and set it to 300f
        public float maxTurnAngle = 15f; //Create a public variable named maxTurnAngle and set it to 15f

        private float currentAcceleration = 0f; //Create a private variable named currentAcceleration and set it to 0f
        private float currentBreakForce = 0f; //Create a private variable named currentBreakingForce and set it to 0f
        private float currentTurnAngle = 0f; //Create a private variable named currentTurnAngle and set it to 0f

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //Get Forward/reverse acceleration from the vertical axis (W and S Keys)
            currentAcceleration = acceleration * Input.GetAxis("Vertical");

            //If we are pressing space, give currentBreakingForce a value.
            if(Input.GetKey(KeyCode.Space)){
                currentBreakForce = breakingForce; //Set currentBreakForce to breakingForce to activate brakes
            }
            else {
                currentBreakForce = 0f; //Set currentBreakForce to 0f
            }

            //Apply acceleration to front wheels
            frontRight.motorTorque = currentAcceleration; //Set the FrontRight motorTorque to match the current Acceleration
            frontLeft.motorTorque = currentAcceleration; //Set the FrontLeft motorTorque to match the current Acceleration

            //Apply acceleration to all wheels
            frontRight.brakeTorque = currentBreakForce; //Set the FrontRight brakeTorque to match the current BreakForce
            frontLeft.brakeTorque = currentBreakForce; //Set the FrontLeft brakeTorque to match the current BreakForce
            backLeft.brakeTorque = currentBreakForce; //Set the BackRight brakeTorque to match the current BreakForce
            backRight.brakeTorque = currentBreakForce; //Set the BackLeft brakeTorque to match the current BreakForce

            //Take care of the steering
            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
            frontLeft.steerAngle = currentTurnAngle;
            frontRight.steerAngle = currentTurnAngle;

            UpdateWheel(frontLeft, frontLeftTransform); //Call out the UpdateWheel function for frontLeft and frontLeftTransform variables
            UpdateWheel(frontRight, frontRightTransform); //Call out the UpdateWheel function for frontRight and frontRightTransform variables
            UpdateWheel(backLeft, backLeftTransform); //Call out the UpdateWheel function for backLeft and backLeftTransform variables
            UpdateWheel(backRight, backRightTransform); //Call out the UpdateWheel function for backRight and backRightTransform variables
        }

        //Create a void called UpdateWheel for Updating thw wheel's collider position and transform rotation
        void UpdateWheel(WheelCollider col, Transform trans) {
            //Get Vehicle Collider State
            Vector3 position; //Create a Vector3 variable called position
            Quaternion rotation; //Create a Quaternion variable caleld rotation
            col.GetWorldPose(out position, out rotation); //Create a col.GetWorldPose variable

            //Set Vehicle transform state
            trans.position = position;
            trans.rotation = rotation;
        }

    }   
}
