using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    // [Header("EfectoDesvanecer")]
    // public Material prefabMaterial;

    [Header("Gun")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject arcoPrefab;
    [SerializeField] Transform arcoPoint;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed = 40f;

    [Header("effects")]
    [SerializeField] GameObject effectSpawn;
    [SerializeField] Transform effectPoint;
    [SerializeField] GameObject effectSpawn2;
    

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
            
        }else if(Input.GetKeyUp(KeyCode.L))anim.SetBool("isArrowAttack",false);
    }

    private void Shoot()
{
    anim.SetBool("isArrowAttack",true);
    // Instanciar un objeto de bala en la posición y rotación del objeto "firePoint"
    GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    GameObject newEffect = Instantiate(effectSpawn, effectPoint.position, effectPoint.rotation);
    GameObject newEffect2 = Instantiate(effectSpawn2, effectPoint.position, effectPoint.rotation);
    GameObject arcoInstance = Instantiate(arcoPrefab, arcoPoint.position, arcoPoint.rotation);
   
    // Obtener el componente Rigidbody del objeto de la bala
    Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
    // Rigidbody effectRigidbody = newEffect.GetComponent<Rigidbody>();

    // Aplicar una fuerza al objeto de la bala en la dirección hacia la cual está apuntando "firePoint"
    bulletRigidbody.AddForce(firePoint.up * bulletSpeed, ForceMode.Impulse);
    // bulletRigidbody.AddForce(firePoint.up * bulletSpeed, ForceMode.Impulse);

    // Destruir el objeto de la bala después de 10 segundos
    Destroy(newBullet, 10f);
    Destroy(arcoInstance,0.8f);
    // anim.SetBool("isArrowAttack",false);
            // anim.SetBool("isArrowAttack",false);
}
// void Desvanecer()
// {
//     float alphaValue = prefabMaterial.color.a;
//     alphaValue -= Time.deltaTime / 2000; // Cambia 2 por la velocidad de desvanecimiento que desees

//     Color newColor = prefabMaterial.color;
//     newColor.a = alphaValue;
//     prefabMaterial.color = newColor;

//     if (alphaValue <= 0)
//     {
//         // Destroy(arcoInstance,0.5f);
//     }
// }
}
