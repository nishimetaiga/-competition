using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContllole : MonoBehaviour
{
    public float speed = 0.0f;
    public Animator anim;

    //float s = 0.0f;
    //float s1 = 0.0f;

    private Rigidbody rB;

    Vector3 moveDirection;
    public float moveTurnSpeed = 10f;

    private float x, z;

    private void Ani()
    {
        anim.SetFloat("Blend", 1.0f);
        anim.SetBool("hebi Trigger", true);

        // Debug.Log("L_Stick_H");
    }

    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");


        if (Input.GetKey("joystick button 3"))
        {
            anim.SetBool("kami Trigger", true);
            Debug.Log("button3");

        }

        if (lsv != 0)
        {
            z = Input.GetAxis("Vertical");
            Ani();
        }

        if (lsh != 0)
        {
            x = Input.GetAxis("Horizontal");
            Ani();
            //再開

        }
        else if (lsh == 0)
        {
            anim.SetBool("hebi Trigger", false);
            //一時停止
            anim.SetFloat("Blend", 0.0f);

            //Debug.Log("animT");
        }

        if (Input.GetKeyDown("joystick button 0"))
        {
            anim.SetBool("hebi Trigger", true);
             //Debug.Log("ButtonA");
        }
        else
        {

        }

        // Look=Quaternion.LookRotation()
        rB.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);

    }
}
