using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit: MonoBehaviour
{
    public Animator anim;

    [SerializeField] private GaugeProcessing GP;
    //敵のMAX体力と現在(仮)
    public int MaxHp = 3;
    int currentHp;
    public Slider Hp;
    ////満腹ゲージのMAXと現在
    //int maxFull = 100;
    //int currentFull;
    //public Slider Full;
    public float CountNumber = 0.0f;
    private float CountDown;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Hp.value = 1;
        currentHp = MaxHp;
        CountDown = CountNumber;
        Debug.Log("Start currentHp : " + currentHp);
    }

    void Update()
    {
        CountDown -= Time.deltaTime;
        Debug.Log(GP.currentFull);
    }

    void OnCollisionEnter(Collision other)
    {

        //レイヤー0を取得している
        AnimatorClipInfo[] clip = anim.GetCurrentAnimatorClipInfo(0);

        AnimatorStateInfo stat = anim.GetCurrentAnimatorStateInfo(0);
        float len = stat.length;

        //クリップ(アニメーション)名を取得
        string clipName =clip[0].clip.name;
        Debug.Log(clipName);

        //Debug.Log("length" +stat.length);
        if (other.gameObject.tag== "enemy"&&clipName=="アーマチュア|カム")
        {
            
            if (CountDown < 0)
            {
                currentHp = currentHp - 1;
                //最大満腹における現在の満腹をSliderに反映。
                Hp.value = (float)currentHp / (float)MaxHp; ;
                Debug.Log("Start currentHp : " + currentHp);
                if (currentHp == 0)
                {
                    GP.currentFull = GP.currentFull + MaxHp;
                    if (GP.currentFull > GP.maxFull) {
                        GP.currentFull = GP.maxFull;
                    }
                    GP.Full.value = (float)GP.currentFull / (float)GP.maxFull;
                    Destroy(other.gameObject, 0.2f);
                    //Debug.Log(GP.currentFull);
                }
                CountDown = CountNumber;
            }
        }
    }
}
