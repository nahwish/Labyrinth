using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollider : MonoBehaviour
{
    public Animator anim;
    public GameObject auraCollider;
    public GameObject auraShine;
    private bool isShieldActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            anim.SetBool("isShield", true);
            auraCollider.SetActive(true);
            Invoke("Shine",1.5f);
            Invoke("DisableAuraCollider", 7f);
            isShieldActive = true;
        }
    }

    private void DisableAuraCollider()
    {
        auraCollider.SetActive(false);
        isShieldActive = false;
    }
    private void Shine(){
        auraShine.SetActive(false);
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.collider.CompareTag("wall"))
        {

            GetComponent<Collider>().enabled = false;
        }
        
    }
   
}
