using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerContllole PC;
    public int level;
    private Text textLevel;
    public GameObject Snake;
    //1レベル上がるごとのサイズ倍率
    public float Size;
    //現在のサイズ
    public float MaxSize;
    //必要な経験値
    public int Mxaken;
    //現在の経験値
    public int Geken = 0;
    //オブジェクトのサイズ
    Vector3 HebiS;
    void Start()
    {
        level = 1;
        textLevel = GameObject.Find("Level").GetComponent<Text>();
        //オブジェクト(ヘビ)のサイズを取得
        HebiS = Snake.GetComponent<Transform>().localScale;
        MaxSize = HebiS.x;
        SetLevelText(level);
    }
    private void SetLevelText(int level)
    {
        textLevel.text = level.ToString();
    }
    public void AddScore(int point)
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Mxaken <= Geken)
        {
            level++;
            PC.Attack++;
            Geken = 0;
            Debug.Log("level");
            SetLevelText(level);
            //サイズをヘビのサイズに×
            MaxSize = MaxSize * Size;
            //必要な経験値を上げる
            Mxaken += Mxaken;
            Debug.Log(Geken);
        }
    }
}

