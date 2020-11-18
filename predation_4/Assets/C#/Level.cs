using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level: MonoBehaviour
{
    private int level;
    private Text textLevel;
    public GameObject Snake;
    public float Size;
    //必要な経験値
    public int Mxaken;
    //現在の経験値
    public int Geken=0;
    Vector3 HebiS;
    void Start()
    {
        level = 0;
        textLevel = GameObject.Find("Level").GetComponent<Text>();
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
        //if (Input.GetKeyDown("joystick button 0"))
        //{
        //現在の経験値が必要な経験値より多い時のレベル処理
        if (Mxaken <= Geken)
        {
            HebiS = Snake.GetComponent<Transform>().localScale;
                
            level++;
            Geken = 0;
            Debug.Log("level");
            SetLevelText(level);
            Snake.GetComponent<Transform>().localScale = new Vector3(HebiS.x * Size, HebiS.y * Size, HebiS.z * Size);
            //必要な経験値を上げる
            Mxaken += Mxaken;
            Debug.Log(Geken);
        }
        //}
    }
}

