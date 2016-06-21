﻿using UnityEngine;
using System.Collections;

public class Scr_VehicleController : MonoBehaviour {

    public float accelTorque = 25f; // Effectively controls the vehicle's speed
    public float wheelSize = 4.0f; // Sets the size of the wheels
    public float maxSuspensionDistance = 5.0f; // How far down does the wheel's suspension reach

    public WheelCollider[] Wheels; // Array to store all the wheels

    private float throttlePercentage = 1.0f; // Number between 0 and 1. Controls how much of the accelTorque to use

    // Use this for initialization
    void Start () {
        foreach (WheelCollider wheel in Wheels)
        {
            wheel.suspensionDistance = maxSuspensionDistance;
            wheel.radius = wheelSize;
        }
    }
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        UpdateVehicleMovement();
	}

    // Called from FixedUpdate. Handles moving the vehicle.
    void UpdateVehicleMovement()
    {
        //TEMPORARY
        //Sets the throttle to 1 if space is down, and 0 if it's not
        if (Input.GetKey("space"))
            updateThrottlePercentage(1.0f);
        else
            updateThrottlePercentage(0.0f);

        float scaledTorque = throttlePercentage * accelTorque; // Scale the tourqe based on the throttle percentage

        foreach (WheelCollider wheel in Wheels)
        {
            wheel.motorTorque = scaledTorque;
            wheel.brakeTorque = 0;
        }
    }

    void updateThrottlePercentage(float newThrottlePercentage)
    {
        throttlePercentage = newThrottlePercentage;
    }
}
