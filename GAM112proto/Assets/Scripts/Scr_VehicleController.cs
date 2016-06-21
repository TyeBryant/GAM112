using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Scr_VehicleController : MonoBehaviour {

    public float accelTorque = 25f; // Effectively controls the vehicle's speed
    public float wheelSize = 4.0f; // Sets the size of the wheels
    public float maxSuspensionDistance = 5.0f; // How far down does the wheel's suspension reach

    public WheelCollider[] Wheels; // Array to store all the wheels

    public Text speedo;

    private float throttlePercentage = 0.0f; // Number between 0 and 1. Controls how much of the accelTorque to use

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        foreach (WheelCollider wheel in Wheels)
        {
            wheel.suspensionDistance = maxSuspensionDistance;
            wheel.radius = wheelSize;
        }
        rb = GetComponent<Rigidbody>();
    }
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        UpdateVehicleMovement();
        VelocityUpdater();
	}

    // Called from FixedUpdate. Handles moving the vehicle.
    void UpdateVehicleMovement()
    {
        float scaledTorque = throttlePercentage * accelTorque; // Scale the tourqe based on the throttle percentage

        foreach (WheelCollider wheel in Wheels)
        {
            wheel.motorTorque = scaledTorque;
            wheel.brakeTorque = 0;
        }
    }

    // Accessed directly by UI slider
    public void updateThrottlePercentage(float newThrottlePercentage)
    {
        throttlePercentage = newThrottlePercentage;
    }

    void VelocityUpdater ()
    {
        float currentVelocity;
        currentVelocity = Vector3.Magnitude(rb.velocity);
        speedo.text = (int)currentVelocity + "m/s";
    }
}
