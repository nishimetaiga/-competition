using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanntei : MonoBehaviour
{
    public int HPG = 0;

    public BoxCollider ag;

    private float Mtime = 0.0f; 

    private void Start()
    {
        if (ag != null)
        {
            ag.enabled = false;
        }

        //Collider c = this.gameObject.transform.FindChild("hebi/aaa/Bone.033/Bone.032/Bone.035/Cube.002").gameObject.GetComponent<BoxCollider>();
        //c.enabled = false;
    }
    private void OnTriggerEnter(Collider c)
    {
        if (Mtime >= 1)
        {
            if (c.gameObject.tag == "enemy")
            {
                HPG = 1;
                Mtime = 0.0f;
            }
          
        }
    }
    public int GetHPG()
    {
        return HPG;
    }

    private void Update()
    {
        if (Mtime < 2)
        {
            Mtime += 0.001f;
            //Debug.Log(Mtime);
        }
    }
}
