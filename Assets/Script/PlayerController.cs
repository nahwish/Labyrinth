using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    [Range(0, 8)]
    float walkSpeed = 3f;

    [SerializeField]
    [Range(8, 15)]
    float runSpeed = 9f;
    float walking;
    float running;
    public float mHorizontal;
    public float mVertical;

    [SerializeField]
    UnityEngine.CharacterController controller; // Utiliza UnityEngine.CharacterController

    // Variables para el salto
    public float jumpForce = 0.3f;
    private bool isJumping = false;
    private float verticalVelocity = 0f;
    float mGravity = -9.81f;
    public Vector3 playerVelocity;

    [SerializeField]
    float maxTiltAngle = 45f; // Ángulo máximo de inclinación hacia adelante
    public float rotationSpeed = 100.0f;
    Vector3 move;
    // Variable para controlar el tiempo de flotación
    private float floatingTime = 5f; // 5 segundos de flotación
    private float currentFloatingTime = 0f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetAxisInput();
        UpdatePosition();
        
        
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
        RotateCharacter();

        
        playerVelocity.y += mGravity * Time.deltaTime;
        if (
            Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.S)
        )
        {
            move = new Vector3(mHorizontal, playerVelocity.y, mVertical);
            move = this.transform.TransformDirection(move);
            controller.Move(move * Time.deltaTime * walkSpeed);
        }
    }

    void RotateCharacter()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}