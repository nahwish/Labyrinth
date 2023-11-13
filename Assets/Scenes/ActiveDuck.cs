using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDuck : MonoBehaviour
{
    [SerializeField] GameObject duck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            duck.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            duck.SetActive(false);
        }
    }
}
