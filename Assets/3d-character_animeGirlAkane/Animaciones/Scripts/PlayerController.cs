using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 3f;
    float mHorizontal;
    float mVertical;
    CharacterController controller;
    float mGravity = 9.8f;
    Vector3 playerVelocity;
    Camera cameraRay;
    Vector3 mouseWorldPosition;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;
        if (!isGrounded)
        {
            playerVelocity.y += mGravity * Time.deltaTime;
        }
        else
        {
            playerVelocity.y = 0f;
        }

        cameraRay = Camera.main;

        RaycastHit hitData;
        int layerMask = LayerMask.GetMask("Floor");
        if (Physics.Raycast(cameraRay.ScreenPointToRay(Input.mousePosition), out hitData, 100, layerMask))
        {
            mouseWorldPosition = hitData.point;
        }
        mouseWorldPosition.y = 0f;
        transform.LookAt(mouseWorldPosition);

        mHorizontal = Input.GetAxis("Horizontal");
        mVertical = Input.GetAxis("Vertical");

        playerVelocity.x = mHorizontal * walkSpeed;
        playerVelocity.z = mVertical * walkSpeed;

        controller.Move(playerVelocity * Time.deltaTime* walkSpeed);
    }
}
