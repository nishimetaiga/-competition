using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bkh : MonoBehaviour
{
    //public SphereCollider KHS;
    //public SphereCollider KHT;
    //public SphereCollider KHD;

    CharacterController Controller;
    Transform Tatget;
    GameObject Player;

    bool InArea = false;

    float Kcount=0.0f;

    private void Start()
    {
        Player = GameObject.FindWithTag("Kesu");
        Tatget = Player.transform;

        Controller = GetComponent<CharacterController>();
    }

    public void OnDetectOblect(Collider collision)
    {
        if (collision.CompareTag("Kesu"))
        {
            //Kcount = 1;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Kesu")
    //    {
    //        if (KHD.CompareTag("Kesu"))
    //        {
    //            Kcount = 2;
    //        }
    //        Kcount = 1;
    //    }
    //}

    private void Update()
    {
        //if (KHD== "Kesu")
        //{
        //    Kcount = 2;
        //}
        if (InArea)
        {
            //座標確認用
            Vector3 direction = Tatget.position - this.transform.position;
           // Debug.Log(direction);
            
            //自分の位置
            Vector3 Apos = this.transform.position;
            //playerの位置
            Vector3 Bpos = Tatget.transform.position;
           
            float distance = Vector3.Distance(Apos, Bpos);      //自分の位置-プレイヤーの位置
            if (distance > 5)
            {
                Kcount = 3.0f;
            }
            else
            {
                if (distance < 5&&distance>1)
                {
                    Kcount = 1.0f;
                }
                else
                {
                    Kcount = 0.0f;
                }
            }
            Debug.Log(distance);
            Vector3 velocety = direction * Kcount;
            velocety.y = 0.0f;
            Controller.Move(velocety * Time.deltaTime);
           // Debug.Log(velocety);
        }

        //Debug.Log(Apos);      //自分の位置
        //Debug.Log(Bpos);      //playerの位置
       //Debug.Log(InArea);
        //Debug.Log(Kcount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kesu")
        {
            InArea = true;
        }
    }
}
