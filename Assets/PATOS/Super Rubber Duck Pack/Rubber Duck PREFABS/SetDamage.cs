using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamage : MonoBehaviour
{
    public ProgressBar Pb;
    // Start is called before the first frame update
    public int damageDuck = 10;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Pb.BarValue -= damageDuck;
        }
    }
}
