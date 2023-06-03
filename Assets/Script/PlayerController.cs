using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    [SerializeField] [Range(0,8)] float walkSpeed = 3f;
    [SerializeField] [Range(8,15)] float runSpeed = 9f;
    float walking;
    float running;
    public float mHorizontal;
    public float mVertical;
    [SerializeField] UnityEngine.CharacterController controller; // Utiliza UnityEngine.CharacterController
    float mGravity = -9.81f;
    public Vector3 playerVelocity;

    [SerializeField] float maxTiltAngle = 45f; // Ángulo máximo de inclinación hacia adelante

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        UpdatePosition();
        GetAxisInput();
        RotationPlayer();
    
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
        if( controller.isGrounded && playerVelocity.y < 0 )
        {
            playerVelocity.y = 0;
        }
        playerVelocity.y += mGravity * Time.deltaTime;

        Vector3 move = new Vector3(mHorizontal, playerVelocity.y, mVertical);
        move = this.transform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * walkSpeed);
    }
 
   void RotationPlayer()
{
    if (Input.GetKey(KeyCode.LeftArrow))
    {
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * -40 * Time.deltaTime);
        transform.rotation = deltaRotation * transform.rotation;
    }
    
    if (Input.GetKey(KeyCode.RightArrow))
    {
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * 40 * Time.deltaTime);
        transform.rotation = deltaRotation * transform.rotation;
    }
}

}


        //bool isGrounded = Physics.Raycast(transform.position, Vector3.down, controller.height / 2f + 0.1f);

        // // Inclinar hacia adelante
        // float tiltAngle = Mathf.Clamp(playerVelocity.magnitude * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        // transform.rotation = Quaternion.Euler(tiltAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        //controller.Move(playerVelocity * Time.deltaTime);