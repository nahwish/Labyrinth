using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePinter : MonoBehaviour
{
   // -Mouse Pointer -------------
    Vector3 mouseWorldPosition;
    Ray cameraRay;

    void Update()
    {
        MousePosition();
        RayCast();
    }
    
    void MousePosition()
    {
        mouseWorldPosition = new Vector3(mouseWorldPosition.x, 0f,mouseWorldPosition.z);
        transform.LookAt(mouseWorldPosition);
    }
   void RayCast()
    {
        // Selecciona todos los layers menos el número 3
        int layerMask = ~(1 << 3);

        // Crea un rayo desde la posición de la cámara hasta la posición del puntero del mouse
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Dibuja una línea de depuración para el rayo
        Debug.DrawRay(cameraRay.origin, cameraRay.direction * 500, Color.red);

        // Almacena información sobre el objeto que ha sido impactado por el rayo
        RaycastHit hitData;

        // Lanza el rayo y comprueba si ha impactado un objeto en la capa seleccionada
        if (Physics.Raycast(cameraRay, out hitData, 500, layerMask))
        {
            // Si el objeto impactado tiene la etiqueta "Floor"
            if (hitData.collider.gameObject.tag == "Floor")
            {
                // Almacena la posición del punto de impacto en el mundo
                mouseWorldPosition = hitData.point;
            }
        }
    }
}
