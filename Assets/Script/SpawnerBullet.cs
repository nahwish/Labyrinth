using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerBullet : MonoBehaviour
{

    [Header("Arco y Flecha")]
    
    [Tooltip("Flecha a instanciar")] [SerializeField] GameObject flechaPrefab;
    [Tooltip("Prefab del arma")] [SerializeField] GameObject arcoPrefab;

    [Header("posición del Arco y Flecha")]
    [Tooltip("Punto desde donde se instancia el arma")] [SerializeField] Transform posicionArco;
    [Tooltip("Punto desde donde sale la flecha")] [SerializeField] Transform posicionFlecha;
    [SerializeField] float bulletSpeed = 40f;

    [Header("effects")]

    [SerializeField] GameObject cameraSpawner;
    [SerializeField] GameObject mira;

    [Header("effects")]
    [SerializeField] Animator anim;
    

// GameObject arcoInstance;
    void Start()
{
    // prefabMaterial = GetComponent<Renderer>().material;
}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Shoot();
            
        }
        if (Input.GetKey(KeyCode.M))
        {
            
            anim.SetBool("isShield",true);
        }
        else{
            anim.SetBool("isShield",false);
        }
        
        if(Input.GetKey(KeyCode.Mouse1)){
            cameraSpawner.SetActive(true);
            mira.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
            else if(Input.GetKeyUp(KeyCode.Mouse0))anim.SetBool("isArrowAttack",false);
        }else{
            cameraSpawner.SetActive(false);
            mira.SetActive(false);

        }
    }

    private void Shoot()
{
    anim.SetBool("isArrowAttack",true);
    // Instanciar un objeto de bala en la posición y rotación del objeto "posicionFlecha"
    GameObject newBullet = Instantiate(flechaPrefab, posicionArco.position, posicionArco.rotation);
    GameObject arcoInstance = Instantiate(arcoPrefab, posicionArco.position, posicionArco.rotation);
   
    // Obtener el componente Rigidbody del objeto de la bala
    Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

    // Aplicar una fuerza al objeto de la bala en la dirección hacia la cual está apuntando "posicionFlecha"
    bulletRigidbody.AddForce(posicionFlecha.up * bulletSpeed, ForceMode.Impulse);

    // Destruir el objeto de la bala después de 10 segundos
    Destroy(newBullet, 10f);
    Destroy(arcoInstance,0.8f);

}

void OnTriggerExit(Collider other)
{
    if (other.CompareTag("laberinto"))
    {
        if(Input.GetKey(KeyCode.Mouse1)){
            cameraSpawner.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
            else if(Input.GetKeyUp(KeyCode.Mouse0))anim.SetBool("isArrowAttack",false);
        }else{
            cameraSpawner.SetActive(false);

        }
    }
}
}
