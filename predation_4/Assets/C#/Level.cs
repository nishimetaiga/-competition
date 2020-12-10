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
    public float CurrentSize;
    //必要な経験値
    public int Mxaken;
    //現在の経験値
    public int CurrentKen = 0;
    //必要な経験値に不要な経験値
    private int Aken = 0;
    //オブジェクトのサイズ
    Vector3 HebiS;

    //levelupの画像の処理の変数一覧
    public Image LevelUp;
    float lu;
    float lus;
    bool luf;
    void Start()
    {
        level = 1;
        textLevel = GameObject.Find("Level").GetComponent<Text>();
        //オブジェクト(ヘビ)のサイズを取得
        HebiS = Snake.GetComponent<Transform>().localScale;
        CurrentSize = HebiS.x;
        SetLevelText(level);
        lu = 0.0f;
        lus = 0.0f;
        LevelUp.fillAmount = 0;
        luf = false;
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

        LevelUpimg();

        if (Mxaken <= CurrentKen)
        {
            if (luf == true && PC.GameOverFlag == false) 
            {
                Time.timeScale = 0;  // 時間停止
                level++;
                PC.Attack++;
                PC.speed += PC.speed;
                if (CurrentKen > 0)
                {
                    Aken = CurrentKen - Mxaken;
                    CurrentKen = Aken;
                }
                SetLevelText(level);
                //サイズをヘビのサイズに×
                CurrentSize = CurrentSize * Size;
                //必要な経験値を上げる
                Mxaken += Mxaken;
                luf = false;
                //Debug.Log(Geken);
            }
        }
    }

    //levelupの画像の処理
    private void LevelUpimg()
    {
        lu = (float)CurrentKen / (float)Mxaken;
        if (lu > lus)
        {
            lus += 0.05f;
            LevelUp.fillAmount += 0.05f;
        }

        if (lus >= 1)
        {
            lus = 0.0f;
            LevelUp.fillAmount = 0;
            luf = true;
        }
        //LevelUp.fillAmount = (float)LE.Geken / (float)LE.Mxaken;
    }
}

