using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public Animator anim;

    private CharacterController _characterController;
    private Vector3 _moveVelocity;
    //private Rigidbody rB;

    void Start()
    {
        //rB = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float lsh = Input.GetAxis("L_Stick_H");

        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
        float duration = currentState.length;

        //Yボタンが押されてかの判定
        if (Input.GetKey("joystick button 3"))
        {
            anim.SetBool("kami Trigger", true);
            Debug.Log("button3");
           
        }
        
        //Lステックが左右に傾いたときの判定
        if (lsh != 0) 
        {
            //再開
            anim.SetFloat("Blend", 1.0f);
            anim.SetBool("hebi Trigger", true);
            _moveVelocity.x = Input.GetAxis("Horizontal") * speed;
            //rB.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);
            //rB.AddForce(x * speed, 0, 0, ForceMode.Impulse);
            _characterController.Move(_moveVelocity * Time.deltaTime);
            Debug.Log("L_Stick_H");
        }
        else if (lsh == 0)
        {
            anim.SetBool("hebi Trigger", false);
            //一時停止
            anim.SetFloat("Blend", 0.0f);
            //Debug.Log("animT");
        }
    }
}
