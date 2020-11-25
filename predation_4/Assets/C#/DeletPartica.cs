﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletPartica : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (particle.isStopped) //パーティクルが終了したか判別
        {
            Destroy(this.gameObject);//パーティクル用ゲームオブジェクトを削除
        }
    }

    private void ParticalLevel()
    {

    }
}
