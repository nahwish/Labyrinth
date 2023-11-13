using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBar : MonoBehaviour
{
    public ProgressBar Pb;
    public int Value = 65;
    Animator anim;


    // Update is called once per frame
    void Start()
    {
        Pb.BarValue = Value;
    }
    
    
}
