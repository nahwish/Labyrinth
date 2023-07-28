using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Obtener el arco y flecha")]
    public static bool canMove = true;
    [SerializeField] [Tooltip("Arco del personaje")]GameObject arrowObject;
    // [SerializeField] [Tooltip("efecto para cuando obtiene el arco")] GameObject effectoArco;
    [SerializeField] [Tooltip("Mensaje una vez obtenido el arco y flecha")] GameObject textoArco1;
    [SerializeField] [Tooltip("Mensaje una vez obtenido el arco y flecha")] GameObject textoArco2;
    [SerializeField] [Tooltip("Mensaje una vez obtenido el arco y flecha")] GameObject textoArco3;
    Animator anim;

    [SerializeField] [Range(0, 8)] float walkSpeed = 3f;

    [SerializeField] [Range(8, 15)] float runSpeed = 9f;
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
    bool primerTexto = false;
    bool segundoTexto = false;
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
        if(canMove)
        {
            GetAxisInput();
            UpdatePosition();
        }
        BuffEfecto();
       
        
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

    // Verificar si el controlador está en el suelo antes de aplicar la gravedad.
    if (controller.isGrounded)
    {
        playerVelocity.y = 0f;
    }

    // Aplicar gravedad.
    playerVelocity.y += mGravity * Time.deltaTime;

    // Cambiar la velocidad de caminar dependiendo de si se presiona la tecla de correr (LeftShift).
    walkSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

    // Verificar si el jugador está intentando moverse (presionando alguna tecla de movimiento).
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
    {
        // Actualizar la animación de correr/caminar según la velocidad.
        anim.SetBool("isRun", walkSpeed == runSpeed);

        move = new Vector3(mHorizontal, playerVelocity.y, mVertical);
        move = this.transform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * walkSpeed);
    }
    else
    {
        // Si el jugador no está intentando moverse, detener la animación de correr.
        anim.SetBool("isRun", false);
    }
}


    void RotateCharacter()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
    // Verificar si el objeto colisionado es el objeto contenedor
    if (other.gameObject.CompareTag("shieldArrow")) {
        // Obtener la referencia al objeto "arco" a través del objeto contenedor
        Transform arcoTransform = other.gameObject.transform.Find("arco");

        // Verificar si se encontró el objeto "arco" dentro del contenedor
        if (arcoTransform != null) {
            // Instantiate(effectoArco,transform.position, Quaternion.identity);
            // effectoArco.SetActive(true);
            textoArco1.SetActive(true);
            
            // Invoke("TextoArco",6f);
            Invoke("BuffEfecto",3f);
            arrowObject.SetActive(false);
            SpawnerBullet.tieneArco = true;
        } else {
            Debug.Log("No se encontró el objeto 'arco' dentro del contenedor.");
        }
    }
}


    void BuffEfecto()
{
    if (Input.GetKeyDown(KeyCode.Return) && (!primerTexto && !segundoTexto))
    {
        textoArco1.SetActive(false);
        textoArco2.SetActive(true);
        primerTexto = true;
    }
    else if (Input.GetKeyDown(KeyCode.Return) && (primerTexto && !segundoTexto))
    {
        textoArco2.SetActive(false);
        textoArco3.SetActive(true);
        segundoTexto = true;
    }
    else if (Input.GetKeyDown(KeyCode.Return) && segundoTexto)
    {
        textoArco3.SetActive(false);
        // Aquí puedes realizar cualquier acción adicional después de que se muestre el tercer texto.
    }
}
    // void TextoArco(){
    //     textoArco.SetActive(false);
    // }
}