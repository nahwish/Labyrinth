using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageExit : MonoBehaviour
{
    [SerializeField] GameObject messageExit;
    public ProgressBarCircle Pb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pb.BarValue >= 100)
        {
            messageExit.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player") && Pb.BarValue <= 100)
        {
            messageExit.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            messageExit.SetActive(false);
        }
    }
}
