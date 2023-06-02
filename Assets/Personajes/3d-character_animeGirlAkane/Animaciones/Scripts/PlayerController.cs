using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    [SerializeField] float walkSpeed = 3f;
    float mHorizontal;
    float mVertical;
    CharacterController controller;
    float mGravity = -9.81f;
    Vector3 playerVelocity;
    Camera cameraRay;
    Vector3 mouseWorldPosition;

    [SerializeField] float maxTiltAngle = 45f; // Ángulo máximo de inclinación hacia adelante

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //bool isGrounded = Physics.Raycast(transform.position, Vector3.down, controller.height / 2f + 0.1f);

       


        mHorizontal = Input.GetAxis("Horizontal");
        mVertical = Input.GetAxis("Vertical");

        playerVelocity.x = mHorizontal * walkSpeed;
        playerVelocity.z = mVertical * walkSpeed;

        // Inclinar hacia adelante
        float tiltAngle = Mathf.Clamp(playerVelocity.magnitude * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        transform.rotation = Quaternion.Euler(tiltAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        //controller.Move(playerVelocity * Time.deltaTime);
    }
}
