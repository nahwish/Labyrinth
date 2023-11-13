using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEscenasManager : MonoBehaviour
{
    private void Awake(){
        var noDestruirEntreEscenas = FindObjectsOfType<SetEscenasManager>();
        if(noDestruirEntreEscenas.Length > 1){
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
