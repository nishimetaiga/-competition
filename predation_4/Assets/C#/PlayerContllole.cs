using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContllole : MonoBehaviour
{
    public float speed = 0.0f;
    public Animator anim;

    private GameObject wakka;
    public GameObject BossEnemy;

    private Rigidbody rB;



    Vector3 moveDirection;
    public float moveTurnSpeed = 10f;

    //プレイヤーの攻撃力
    public int Attack = 1;

    private float x, z;

    [SerializeField] GaugeProcessing Canv;
    [SerializeField] SE se;
   
    public bool ClearOn;
    public bool GameOverFlag;
    Vector3 plY;

    public Text ClearText;
    public Text GameOverText;
    public Text Abutton;
    public Text Bbutton;

    private void Ani()
    {
        anim.SetFloat("Blend", 1.0f);
        anim.SetBool("hebi Trigger", true);

        // Debug.Log("L_Stick_H");
    }

    void Start()
    {
        this.wakka = GameObject.Find("wakka");
        wakka.SetActive(false);

        rB = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        ClearOn = false;
        GameOverFlag = false;
        ClearText.enabled = false;
        GameOverText.enabled = false;
        Abutton.enabled = false;
        Bbutton.enabled = false;
    }

    void Update()
    {
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        plY = transform.position;

        GameFlagManager();

        if (ClearOn == false && GameOverFlag == false)
        {
            //一時停止していない間ボタン入力を有効化する
            if (Time.timeScale != 0)
            {
                if (Input.GetKey("joystick button 3"))
                {
                    anim.SetBool("kami Trigger", true);
                    Debug.Log("button3");

                }

                if (lsv != 0)
                {
                    z = Input.GetAxis("Vertical");
                    Ani();
                }

                if (lsh != 0)
                {
                    x = Input.GetAxis("Horizontal");
                    Ani();
                    //再開

                }
                else if (lsh == 0)
                {
                    anim.SetBool("hebi Trigger", false);
                    //一時停止
                    anim.SetFloat("Blend", 0.0f);

                    //Debug.Log("animT");
                }

                if (Input.GetKeyDown("joystick button 0"))
                {
                    anim.SetBool("hebi Trigger", true);
                    //Debug.Log("ButtonA");
                }
                else
                {

                }

                // Look=Quaternion.LookRotation()
                rB.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);
            }
        }
        else
        {
            if (ClearOn == true)
            {
                GameScenes();
                rB.AddForce(0, 0, 0, ForceMode.Impulse);
                anim.SetFloat("Blend", 0.0f);
                ClearText.enabled = true;
                Abutton.enabled = true;
                Bbutton.enabled = true;
                ClearOn = true;
            }
            else
            {
                if (GameOverFlag == true)
                {
                    GameScenes();
                    wakka.SetActive(true);
                    if (plY.y < 210.0f)
                    {
                        plY.y += 0.1f;
                        transform.position = plY;
                        //plY += 0.01f;
                        //player.transform.position.y += plY;
                    }
                    else
                    {
                        if (plY.y > 200.0f)
                        {
                            Destroy(gameObject, 0.0f);
                        }
                    }
                    rB.AddForce(0, 0, 0, ForceMode.Impulse);
                    anim.SetFloat("Blend", 0.0f);
                    GameOverText.enabled = true;
                    Abutton.enabled = true;
                    Bbutton.enabled = true;
                    //Debug.Log("GameOver");
                }
            }
        }
    }

    private void GameFlagManager()
    {
        if (BossEnemy == null && ClearOn == false)
        {
            se._audio.PlayOneShot(se.GameClearSE);
            ClearOn = true;
        }
        //else
        //{
        //    ClearOn = false;
        //}

        if (Canv.currentHP <= 0 && GameOverFlag == false)
        {
            se._audio.PlayOneShot(se.GameOverSE);
            GameOverFlag = true;
        }

    }

    private void GameScenes()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            SceneManager.LoadScene("title");
        }
        else
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("main");
            }
        }
    }
}
