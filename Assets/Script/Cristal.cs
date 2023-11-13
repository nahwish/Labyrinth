using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour
{
   
    [SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;
    private int cristalesRecolectados = 0; // Variable para contar los cristales recolectados

    [Header("Iconos para el Canva")]
    [SerializeField]
    [Tooltip("icono del cristal")]
    GameObject cristalRosa;

    [SerializeField]
    [Tooltip("icono del cristal")]
    GameObject cristalAzul;

    [SerializeField]
    [Tooltip("icono del cristal")]
    GameObject cristalVerde;

    [Header("Cristal Encontrado")]
    [SerializeField]
    [Tooltip("Cristal encontrado")]
    GameObject cristalRosaObject;

    [SerializeField]
    [Tooltip("Cristal encontrado")]
    GameObject cristalVerdeObject;

    [SerializeField]
    [Tooltip("Cristal encontrado")]
    GameObject cristalAzulObject;

    [Header("Cristales que aparecen en el altar")]
    [SerializeField]
    [Tooltip("Cristal que aparece en el altar")]
    GameObject CristalAzulAltar;

    [SerializeField]
    [Tooltip("Cristal que aparece en el altar")]
    GameObject CristalVerdeAltar;

    [SerializeField]
    [Tooltip("Cristal que aparece en el altar")]
    GameObject CristalRosaAltar;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cristalVerde"))
        {
            cristalVerde.SetActive(false);
            CristalVerdeAltar.SetActive(true);
            Destroy(cristalVerdeObject);
            cristalesRecolectados++;
        }
        if (other.CompareTag("cristalRosa"))
        {
            cristalRosa.SetActive(false);
            CristalRosaAltar.SetActive(true);
            Destroy(cristalRosaObject);
            cristalesRecolectados++;
        }
        if (other.CompareTag("cristalAzul"))
        {
            cristalAzul.SetActive(false);
            CristalAzulAltar.SetActive(true);
            Destroy(cristalAzulObject);
            cristalesRecolectados++;
        }

        // Verificar si se han recolectado los tres cristales
        if (cristalesRecolectados >= 3)
        {
            // Cambiar el valor del "Far Clip Plane" de la cámara a 100
            virtualCamera.m_Lens.FarClipPlane = 100f;
        }
    }
}
