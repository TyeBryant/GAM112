using UnityEngine;
using System.Collections;

public class Scr_VehicleController : MonoBehaviour {

    public float accelTorque = 25f; // Effectively controls the vehicle's speed
    public float brakeTorque = 100f; // Controls brake speed

    private float throttlePercentage = 0.0f; // Number between 0 and 1. Controls how much of the accelTorque to use

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        UpdateVehicleMovement();
	}

    // Called from FixedUpdate. Handles moving the vehicle.
    void UpdateVehicleMovement()
    {
        float scaledTorque = throttlePercentage * accelTorque; // Scale the tourqe based on the throttle percentage
    }

    void updateThrottlePercentage(float newThrottlePercentage)
    {
        throttlePercentage = newThrottlePercentage;
    }
}
