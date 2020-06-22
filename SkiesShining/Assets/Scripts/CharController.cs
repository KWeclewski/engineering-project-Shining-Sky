using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Transform cam;

    public float movementSpeed;
    public float rotationSpeed;

    private Rigidbody rb;
    private float horizontal;
    private float vertical;

    private Vector3 forward;
    private Vector3 right;
    private Vector3 target;

    Animator anim;

    int aprobate = 0;

    public int Aprobate
    {
        get => aprobate;
        set
        {
            if (aprobate + value > 100)
            {
                aprobate = 100;
            }
            else
            {
                aprobate += value;
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (vertical != 0 || horizontal != 0)
        {
            Debug.Log("ruch");
            anim.SetBool("Moving", true);
            anim.SetFloat("Vertical", vertical);
            anim.SetFloat("Horizontal", horizontal);
        } else
        {
            anim.SetBool("Moving", false);
        }
    }

    void FixedUpdate()
    {
        if (vertical != 0 || horizontal != 0)
        {
            forward = cam.forward;
            forward.y = 0;
            forward.Normalize();

            right = cam.right;
            right.y = 0;
            right.Normalize();

            target = forward * vertical + right * horizontal;
            target.Normalize();

            rb.MovePosition(gameObject.transform.position + target * movementSpeed * Time.fixedDeltaTime);

            rb.MoveRotation(Quaternion.Lerp(gameObject.transform.rotation, Quaternion.LookRotation(target, Vector3.up), rotationSpeed * Time.fixedDeltaTime));
        }
    }

    public void LockGameplay()
    {
        this.enabled = false;
        if (Camera.main)
        {
            Camera.main.GetComponent<ThirdPersonOrbitCamBasic>().enabled = false;
        }
    }
    public void UnlockGameplay()
    {
        this.enabled = true;
        if (Camera.main)
        {
            Camera.main.GetComponent<ThirdPersonOrbitCamBasic>().enabled = true;
        }
    }
}
