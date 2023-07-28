using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShiewldArrow : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        Debug.Log( "--->1"+ other.gameObject.name);
    }
    void OnCollisionEnter(Collider other) {
        Debug.Log( "--->2"+ other.gameObject.name);
    }
    void OnTriggerEnter(Collision other) {
        Debug.Log( "--->3"+ other.gameObject.name);
    }
    void OnTriggerEnter(Collider other) {
        Debug.Log( "--->4"+ other.gameObject.name);
    }
}
