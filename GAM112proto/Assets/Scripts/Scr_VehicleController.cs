using UnityEngine;
using System.Collections;

public class Scr_VehicleController : MonoBehaviour {

    public float accelTorque = 25f; // Effectively controls the vehicle's speed
    public float maxSuspensionDistance = 5.0f; // How far down does the wheel's suspension reach

    public WheelCollider[] Wheels; // Array to store all the wheels

    private float throttlePercentage = 1.0f; // Number between 0 and 1. Controls how much of the accelTorque to use

    // Use this for initialization
    void Start () {
        foreach (WheelCollider wheel in Wheels)
        {
            wheel.suspensionDistance = maxSuspensionDistance;
        }
    }
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        UpdateVehicleMovement();
	}

    // Called from FixedUpdate. Handles moving the vehicle.
    void UpdateVehicleMovement()
    {
        float scaledTorque = throttlePercentage * accelTorque; // Scale the tourqe based on the throttle percentage

        foreach(WheelCollider wheel in Wheels)
        {
            wheel.motorTorque = accelTorque;
            wheel.brakeTorque = 0;
        }
    }

    void updateThrottlePercentage(float newThrottlePercentage)
    {
        throttlePercentage = newThrottlePercentage;
    }
}
