using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    float forwardInput, turningInput;
    float forwardVelocity = 8;
    float turnVelocity = 90;
    Rigidbody rb;
    Quaternion targetRotation;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetRotation = transform.rotation;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turningInput = Input.GetAxis("Mouse X");
    }

    void Turn()
    {
        targetRotation *= Quaternion.AngleAxis(turningInput * turnVelocity * Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;
    }

    void Update()
    {
        GetInput();

        Debug.Log(forwardInput);
        Vector3 velocityAdded = new Vector3((transform.forward * forwardInput * forwardVelocity).x, 0, (transform.forward * forwardInput * forwardVelocity).z);
        rb.velocity = velocityAdded;
        Turn();
    }
}
