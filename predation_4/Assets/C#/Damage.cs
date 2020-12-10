using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] EnemyHit EH;
    [SerializeField] GaugeProcessing GP;

    public int damage=25;
    void Update()
    {
        //腐敗した卵を食べた場合
        if (EH.currentHp <= 0)
        {
            GP.currentFull -= damage;
            GP.MP.fillAmount = (float)GP.currentFull / (float)GP.maxFull;
            EH.currentHp = 1;
            Debug.Log("ヘビの体力" + GP.currentHP);
        }
    }
}
