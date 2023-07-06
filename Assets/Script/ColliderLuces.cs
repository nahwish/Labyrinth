using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLuces : MonoBehaviour
{
    [SerializeField] GameObject luces;
    void Start() {
        luces.SetActive(true);
    }

void OnTriggerEnter(Collider other) {
    if(other.CompareTag("lucesInicio")){
        luces.SetActive(true);
}
}
    void OnTriggerExit(Collider other){
        if(other.CompareTag("lucesInicio")){
        luces.SetActive(false);
        }
    }
}
