using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Scr_VehicleController : MonoBehaviour {

    public float accelTorque; // Effectively controls the vehicle's speed
    public float wheelSize = 4.0f; // Sets the size of the wheels
    public float maxSuspensionDistance = 5.0f; // How far down does the wheel's suspension reach

    public WheelCollider[] Wheels; // Array to store all the wheels

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        foreach (WheelCollider wheel in Wheels)
        {
            wheel.suspensionDistance = maxSuspensionDistance;
            wheel.radius = wheelSize;
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        VehicleMovement();
	}

    void VehicleMovement ()
    {
        foreach (WheelCollider wheel in Wheels)
        {
            if (accelTorque < 1)
                wheel.brakeTorque = 20;
            else
                wheel.brakeTorque = 0;

            wheel.motorTorque = accelTorque;
        }     
    }

    public void ThrottleSlider (float sliderValue)
    {
        accelTorque = sliderValue;
    }
}
