using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Scr_VehicleController : MonoBehaviour
{

    [SerializeField]
    private int currentGear;

    [SerializeField]
    private float accelTorque; // Effectively controls the vehicle's speed

    [SerializeField]
    private float wheelSize = 4.0f; // Sets the size of the wheels

    [SerializeField]
    private float maxSuspensionDistance = 5.0f; // How far down does the wheel's suspension reach

    [SerializeField]
    private float accelerationModifier;

    [SerializeField]
    private float brakeTorque;

    [SerializeField]
    private float maxVelocity;

    [SerializeField]
    private float[] gearedAcceleration;

    [SerializeField]
    private float[] maxGearSpeed;

    [SerializeField]
    private WheelCollider[] Wheels; // Array to store all the wheels

    Rigidbody rb;

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

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        VehicleMovement();
    }

    void VehicleMovement()
    {
        float gearTorque;

        foreach (WheelCollider wheel in Wheels)
        {
            if (accelTorque < 1)
                wheel.brakeTorque = brakeTorque;
            else
                wheel.brakeTorque = 0;

            gearTorque = accelTorque * gearedAcceleration[currentGear];

            wheel.motorTorque = gearTorque;
        }
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, 0, maxGearSpeed[currentGear]), rb.velocity.y, rb.velocity.z);
        Debug.Log(rb.velocity);
    }

    public void ThrottleSlider(float sliderValue)
    {
        accelTorque = sliderValue * accelerationModifier;
    }
}