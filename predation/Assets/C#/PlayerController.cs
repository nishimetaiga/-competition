using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public Animator anim;

    private Rigidbody rB;

    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float lsh = Input.GetAxis("L_Stick_H");

        if (lsh != 0)
        {
            //再開
            anim.SetFloat("Blend", 1.0f);
            anim.SetBool("hebi Trigger", true);
            float x = Input.GetAxis("Horizontal");
            //float z = Input.GetAxis("Vertical");
            //rB.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);
            rB.AddForce(x * speed, 0, 0, ForceMode.Impulse);
            Debug.Log("L_Stick_H");

        }
        else if (lsh == 0)
        {
            anim.SetBool("hebi Trigger", false);
            //一時停止
            anim.SetFloat("Blend", 0.0f);
            Debug.Log("animT");
        }
    }
}
