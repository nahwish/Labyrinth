using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    Vector3 playerVelocity;
    float mHorizontal;
    Animator anim;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mHorizontal = playerController.mHorizontal;
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
            
        if (mHorizontal > 0)
            Debug.Log(" y entra");
        {
        }
    }
}
