using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oracle : MonoBehaviour
{
    [SerializeField]
    List<GameObject> weapons;
    int cantWeapons;
    // Start is called before the first frame update
    void Start()
    {
        cantWeapons = weapons.Count;// count es como el "lenght" pero para listas
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
