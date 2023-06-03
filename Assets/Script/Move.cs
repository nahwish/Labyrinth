// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using static UnityEngine.Ray;

// public class Move : MonoBehaviour
// {

//     // - RIGIBODY
//     Rigidbody CharacterRB;
//     // -HEADER 
//     // Ayuda a dividir el área
//     [Header("Movement")]
   
//     [Tooltip("Velocidad normal para caminar")] [SerializeField] [Range(1,15)]private float walkSpeed = 7f;
//     [Tooltip("Velocidad al correr con Shift")] [SerializeField] [Range(1,15)]private float runSpeed = 50f;
//     [Tooltip("Velocidad al correr con Shift")] [SerializeField] [Range(1,15)]private float sprintAcceleration = 50f;
  
//     float rotateSpeed;

//     // variables privadas
//     float horizontalMove;
//     float verticalMove;
//     float movementSpeed;
//     bool isSprinting = false;
//     bool sprintAvailable;
//     bool sprinting;

// private float sprintDuration = 1f; // duración en segundos del sprint
// private float sprintTimer = 0f; // temporizador para controlar la duración del sprint

//     // - ANIM 
//     [SerializeField] Animator anim;
//     KeyCode[] emotionKeys = { KeyCode.Alpha1, KeyCode.Keypad1, KeyCode.Alpha2, KeyCode.Keypad2, KeyCode.Alpha3, KeyCode.Keypad3, KeyCode.Alpha4, KeyCode.Keypad4 };

//      void Start() {
//         {
//             anim = gameObject.GetComponent<Animator>();
//             CharacterRB = gameObject.GetComponent<Rigidbody>();
//             if(anim == null)
//             {
//                 Debug.Log("Falta el componente Animator");
//             }
//             if(CharacterRB == null)
//             {
//                 Debug.Log("Falta el componente Animator");
//             }
//         }
//     }
//     // 60 VECES X SG
//     void Update()
//     { 
//         Movement();
//         RotationPlayer();
//         HandleInput();
//         if( Input.GetKey( KeyCode.P ))anim.SetBool( "isRun", true );
//     }

//     void Movement()
//     {
//         // Obtener los valores de entrada del eje horizontal y vertical
//         verticalMove = Input.GetAxis( "Vertical" );
//         horizontalMove = Input.GetAxis( "Horizontal" );

//         // Definir la velocidad de movimiento basada en si se está corriendo o caminando
//         float movementSpeed = Input.GetKey( KeyCode.LeftShift ) ? runSpeed : walkSpeed;

//         // Definir una nueva variable Vector3 llamada "_move" que representa el movimiento del objeto en el plano XZ
//         Vector3 _move = new Vector3(horizontalMove, 0f, verticalMove);

//         // Comprobar si el jugador está caminando
//         bool isWalking = _move != Vector3.zero && movementSpeed == walkSpeed;

//         // Controlar la animación
//         if (isWalking)
//         {
//             anim.SetBool("isWalk", true);
//             anim.SetBool("isRun", false);
//         }
//         else if (Input.GetKey(KeyCode.LeftShift))
//         {
//             anim.SetBool("isWalk", false);
//             anim.SetBool("isRun", true);
//             Invoke("StopRunning", 2f);
//         }
//         else
//         {
//             anim.SetBool("isWalk", false);
//             anim.SetBool("isRun", false);
//         }

//         // Comprobar si el jugador está corriendo y si el sprint está disponible
//         if (Input.GetKey(KeyCode.LeftShift) && sprintAvailable)
//         {
//             // Comenzar el sprint y establecer la duración del sprint
//             sprinting = true;
//             sprintDuration = 0.5f; // Cambiar la duración del sprint según sea necesario
//             sprintAvailable = false;
//         }

//         // Comprobar si el jugador está corriendo y si el sprint aún está activo
//         if (sprinting && sprintDuration > 0f)
//         {
//             // Aplicar un impulso hacia adelante para el sprint
//             transform.Translate(_move * movementSpeed * Time.deltaTime * 5f);

//             // Reducir la duración del sprint
//             sprintDuration -= Time.deltaTime;
//         }
//         else
//         {
//             // Establecer la variable de sprinting a false si el sprint ha terminado
//             sprinting = false;

//             // Restablecer el sprint disponible si el jugador no está corriendo
//             if (!Input.GetKey(KeyCode.LeftShift))
//             {
//                 sprintAvailable = true;
//             }

//             // Aplicar movimiento normal
//             transform.Translate(_move * movementSpeed * Time.deltaTime);
//         }
//     }
//     void StopRunning()
//     {
//         anim.SetBool("isRun", false);
//     }

//     void ResetMovementSpeed()
//     {
//         // Restablecer la velocidad de movimiento del personaje después del sprint
//         movementSpeed = walkSpeed;
//     }
//     void RotationPlayer()
//     {
//        if (Input.GetKey(KeyCode.LeftArrow))transform.Rotate(Vector3.up, -40 * Time.deltaTime);
//        if (Input.GetKey(KeyCode.RightArrow))transform.Rotate(Vector3.up, 40 * Time.deltaTime);    
//     }

//     void HandleInput()
//     {
//         for (int i = 0; i < emotionKeys.Length; i++)
//         {
//             if (Input.GetKey(emotionKeys[i]))
//             {
//                 anim.SetInteger("emotionsInt", (i / 2) + 1);
//                 break;
//             }
//         }
//     }
    
// }