using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeProcessing : MonoBehaviour
{
    //満腹ゲージのMAXと現在
    int maxFull = 100;
    int currentFull;
    //HPゲージのMAXと現在
    int maxHP = 100;
    int currentHP;
    public Slider Full;
    public Slider HP;
    public float CountNumber = 0.0f;
    private float CountDown;
    void Start()
    {
        Full.value = 1;
        HP.value = 1;
        currentFull = maxFull;
        currentHP = maxHP;
        CountDown = CountNumber;
        Debug.Log("Start currentFull : " + currentFull);
    }

    void Update()
    {
        CountDown -= Time.deltaTime;
        for (int i = maxFull; i > 0; i--)
        {
            if (CountDown < 0)
            {
                //満腹ゲージの処理
                if (currentFull > 0)
                {
                    //現在の満腹から1づつ引く
                    currentFull = currentFull - 1;
                    Debug.Log("After currentFull : " + currentFull);
                    //最大満腹における現在の満腹をSliderに反映。
                    Full.value = (float)currentFull / (float)maxFull; ;
                }

                //HPゲージの処理
                if (currentFull < 1 && currentHP>0)
                {
                    currentHP = currentHP - 1;
                    Debug.Log("After currentFull : " + currentHP);
                    HP.value = (float)currentHP / (float)maxHP; ;
                }
                CountDown = CountNumber;
            }
        }
    }
}
