using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAdjustment : MonoBehaviour
{
    [SerializeField] public Level LE;
    //public float targetScale = 0.1f;
    public float shrinkSpeed = 0.01f;

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < LE.MaxSize)
        {
            transform.localScale += new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed);
        }
    }
}
