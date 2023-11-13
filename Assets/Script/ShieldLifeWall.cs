using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLifeWall : MonoBehaviour
{
    [Tooltip("Pared inicial con collider, no permite pasar al peronaje")] [SerializeField] GameObject wallCollider;
    [Tooltip("Pared Blur que permite pasar al personaje")] [SerializeField] GameObject wallBlur;
    [SerializeField] GameObject animation1; // Objeto de explosión que se instanciará
    [SerializeField] [Tooltip("Vida inicial del enemigo")] [Range(1,100)]
    [Header("Vida inicial del escudo")]
    private float maxhealth = 100f;
    [Header("Vida Actual")]
    [Tooltip("Vida actual del enemigo")]
    public float currentHealth;

    void Start(){
        currentHealth = maxhealth;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Bullets"){
            currentHealth -= 25;
        }
        if(currentHealth <= 0){
            Instantiate(animation1, transform.position, Quaternion.identity);
            wallBlur.SetActive(true);//Activa la pared blur para evitar colision
            wallCollider.SetActive(false);//Desactiva la pared blur para evitar colision
            Destroy (this.gameObject); //Destruye el objeto al llegar a cero
        }
    }
}
