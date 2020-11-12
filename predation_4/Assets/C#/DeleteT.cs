using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteT : MonoBehaviour
{
    public Hanntei Hn;
    private int HPcount;
    public GameObject ggg;
    public int EHP = 2;

    //private void Update()
    //{
    //    HPcount = Hn.GetHPG();
    //    //Destroy(gameObject, 0.1f);
    //    Debug.Log(HPcount);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "Kesu")
        {
            HPcount = Hn.GetHPG();
            EHP = EHP - HPcount;
            Hn.HPG = 0;
           Debug.Log(HPcount);
        }
    }
    private void Update()
    {
        if (EHP <= 0) {
            Destroy(gameObject, 0.1f);
        }
        Debug.Log(EHP);
    }
}
