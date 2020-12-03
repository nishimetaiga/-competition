using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContllole : MonoBehaviour
{
    public float speed = 0.0f;
    public Animator anim;

    public GameObject Gmo;

    private Rigidbody rB;

    public Text ClearText;
    public bool ClearOn;

    Vector3 moveDirection;
    public float moveTurnSpeed = 10f;

    //プレイヤーの攻撃力
    public int Attack = 1;

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
        anim = gameObject.GetComponent<Animator>();
        ClearOn = false;
        ClearText.enabled = false;
    }

    void Update()
    {
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        if (Gmo != null)
        {
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
        else
        {
            rB.AddForce(0, 0, 0, ForceMode.Impulse);
            anim.SetFloat("Blend", 0.0f);
            ClearText.enabled = true;
            ClearOn = true;
        }
    }
}
