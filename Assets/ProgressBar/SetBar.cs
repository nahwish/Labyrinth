using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBar : MonoBehaviour
{
    public ProgressBar Pb;
    public int Value = 100;
    Animator anim;


    // Update is called once per frame
    void Start()
    {
        Pb.BarValue = Value;
        anim = GetComponent<Animator>();
    }
    void Update() {
    if(Pb.BarValue == 0){
        anim.Set
    }
        
    }
    
}
