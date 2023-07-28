using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    public ProgressBarCircle Pb;
    bool isLoaded = true;
    
    [SerializeField]
    GameObject BarExit;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Pb.BarValue >= 100)
        {
            isLoaded = false;
            BarExit.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player") && isLoaded)
        {
            BarExit.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            BarExit.SetActive(false);
        }
    }
}
