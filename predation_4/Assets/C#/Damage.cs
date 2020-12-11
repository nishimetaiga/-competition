using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] EnemyHit EH;
    [SerializeField] GaugeProcessing GP;

    public int damage=25;
    private AudioSource audio;
    public AudioClip PoisonSound;
    public GameObject dokuro;
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        //腐敗した卵を食べた場合
        if (EH.currentHp <= 0)
        {
            //SEを鳴らす
            audio.PlayOneShot(PoisonSound);
            Instantiate(dokuro, this.transform.position, Quaternion.identity);
            //プレイヤーの満腹ゲージをdamage分減らす
            GP.currentFull -= damage;
            GP.MP.fillAmount = (float)GP.currentFull / (float)GP.maxFull;
            EH.currentHp = 1;
            Debug.Log("ヘビの体力" + GP.currentHP);
        }
    }
}
