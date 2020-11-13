using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level: MonoBehaviour
{
    private int level;
    private Text textLevel;
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
        if (Input.GetKeyDown("joystick button 0"))
        {
            level++;
            Debug.Log("level");
            SetLevelText(level);
        }
    }
}

