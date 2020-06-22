using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//U need to add character to script that script need to know what to follow after

public class CamController : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset = new Vector3(0, 1, -3);
    CharController charController;
    Vector3 destination = Vector3.zero;
    private float velocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetCameraTarget(target);
    }

    private void SetCameraTarget(Transform t)
    {
        target = t;

        if (target != null)
        {
            if (target.GetComponent<CharController>())
            {
                charController = target.GetComponent<CharController>();
            }
            else
            {
                Debug.Log("No character controller in object");
            }
        }
        else
        {
            Debug.Log("no target for camera to follow was set");
        }
    }

    private void LateUpdate()
    {
        Moving();
        LookingAtTarget();
    }

    private void LookingAtTarget()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, target.eulerAngles.y, 0);
    }

    private void Moving()
    {
        destination = charController.TargetRotation * cameraOffset;
        destination += target.position;
        transform.position = destination;
    }
}
