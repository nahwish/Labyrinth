using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject animation1; // Objeto de explosión que se instanciará
    [SerializeField] [Tooltip("Vida inicial del enemigo")] [Range(1,100)]
    [Header("Vida inicial")]
    private float maxhealth = 100f;
    [Tooltip("Vida actual del enemigo")]
    [Header("Vida Actual")]
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
            Destroy (this.gameObject); //Destruye el objeto al llegar a cero
        }
    }
    void OnColliderEnter(Collider other){
        if(other.gameObject.tag == "Bullets"){
            currentHealth -= 50;
        }
        if(currentHealth <= 0){
            Instantiate(animation1, transform.position, Quaternion.identity);
            Destroy (this.gameObject); //Destruye el objeto al llegar a cero
        }
    }
}
