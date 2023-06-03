using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    [SerializeField] float walkSpeed = 3f;
    float walking;
    [SerializeField] float runSpeed = 5f;
    float running;
    float mHorizontal;
    float mVertical;
    [SerializeField] UnityEngine.CharacterController controller; // Utiliza UnityEngine.CharacterController
    float mGravity = -9.81f;
    Vector3 playerVelocity;

    [SerializeField] float maxTiltAngle = 45f; // Ángulo máximo de inclinación hacia adelante

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        UpdatePosition();
        GetAxisInput();
    }

    void GetAxisInput()
    {
        mHorizontal = Input.GetAxisRaw("Horizontal");
        mVertical = Input.GetAxisRaw("Vertical");
        playerVelocity.x = mHorizontal * walkSpeed;
        playerVelocity.z = mVertical * walkSpeed;
    }

    void UpdatePosition()
    {
        Vector3 move = new Vector3(mHorizontal, playerVelocity.y, mVertical);
        move = this.transform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * walkSpeed);
    }
}


        //bool isGrounded = Physics.Raycast(transform.position, Vector3.down, controller.height / 2f + 0.1f);

        // // Inclinar hacia adelante
        // float tiltAngle = Mathf.Clamp(playerVelocity.magnitude * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        // transform.rotation = Quaternion.Euler(tiltAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        //controller.Move(playerVelocity * Time.deltaTime);