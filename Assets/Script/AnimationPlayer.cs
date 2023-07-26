using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [Header("Animacion para la muerte del personaje")]
    [Tooltip("Barra de vida del personaje")] [SerializeField] ProgressBar Pb;
    [SerializeField] PlayerController playerController;

    Vector3 playerVelocity;
    float mHorizontal;
    float mVertical;
    [Tooltip("Maquina de animacion del personaje")] Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mHorizontal = playerController.mHorizontal;
        mVertical = playerController.mVertical;
        UpdateAnimation();
        Dance();
        
    }

    void UpdateAnimation()
    {
            
        if (mVertical > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift)) 
            {
                anim.SetBool("isWalk", false);
                anim.SetBool("isRun", true);
            }
            anim.SetBool("isRun", false);
            anim.SetBool("isWalk", true);
        }else{
            anim.SetBool("isWalk", false);

        }

        if(Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalkL", true);
        }else{
            anim.SetBool("isWalkL",false);
        }
        if(Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalkB", true);
        }else{
            anim.SetBool("isWalkB",false);
        }
    }
       void Dance(){
        if(Input.GetKey(KeyCode.B)){
            anim.SetBool("dance",true);
            }else{anim.SetBool("dance",false);}
    }
    

}
