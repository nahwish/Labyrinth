using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarExit : MonoBehaviour
{
   public ProgressBarCircle Pb;
    public int Value = 0;
    Animator anim;


    // Update is called once per frame
    void Start()
    {
        Pb.BarValue = Value;
    }
}
