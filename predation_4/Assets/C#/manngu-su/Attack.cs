using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    //public BoxCollider Bx;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider Bx)
    {
        if (Bx.gameObject.tag=="Player")
        {
            anim.SetBool("Atacck", true);
        }
        else
        {
            anim.SetBool("Atacck", false);
        }
    }
}
