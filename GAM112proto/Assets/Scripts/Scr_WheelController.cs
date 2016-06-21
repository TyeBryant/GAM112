using UnityEngine;
using System.Collections;

public class Scr_WheelController : MonoBehaviour {

    public WheelCollider wheelCollider;
    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        myTransform = this.transform; // Save our Transform
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        UpdateWheelHeight();
    }

    void UpdateWheelHeight()
    {
        Vector3 localPosition = myTransform.localPosition; // Create a new local transform which can be altered.
        WheelHit hit = new WheelHit(); // Stores info about the wheel hitting the ground

        // Check if our wheel has hit the ground
        if (wheelCollider.GetGroundHit(out hit))
        {
            // Find the y coordinate of the hit and move the wheel to that point
            float hitY = wheelCollider.transform.InverseTransformPoint(hit.point).y;
            localPosition.y = hitY + wheelCollider.radius;
        }
        else
        {
            // No contact with ground, just extend wheel position with suspension distance
            localPosition = Vector3.Lerp(localPosition, -Vector3.up * wheelCollider.suspensionDistance, .05f);
        }
        // Actually update the position
        myTransform.localPosition = localPosition;
    }
}
