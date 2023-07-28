using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    [SerializeField]
    GameObject body;

    [SerializeField]
    GameObject additionalCamera;

    [SerializeField]
    GameObject oraculoFP;


    [SerializeField]
    GameObject oraculo;

    [SerializeField]
    GameObject mira;

    [SerializeField]
    GameObject cameraSpawner;

    [SerializeField]
    GameObject cameraRegular;

   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            additionalCamera.SetActive(true);
            oraculo.SetActive(false);
            oraculoFP.SetActive(true);
            mira.SetActive(true);
            body.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            body.SetActive(true);
            oraculoFP.SetActive(false);
            mira.SetActive(false);
            oraculo.SetActive(true);
            additionalCamera.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            cameraSpawner.SetActive(true);
            cameraRegular.SetActive(false);
        }
        else
        {
            cameraSpawner.SetActive(false);
            cameraRegular.SetActive(true);
        }
    }
}
