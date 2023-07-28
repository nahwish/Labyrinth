using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("shield"))
        {
            Debug.Log("Desactivar collider de la caja");
            GetComponent<Collider>().enabled = false;
        }
       
    }
}

