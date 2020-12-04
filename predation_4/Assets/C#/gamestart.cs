using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{
    public GameObject Cgm;
    public GameObject Cgms;
    private bool BS;

    private void Start()
    {
        Cgm.SetActive(true);
        Cgms.SetActive(false);
    }

    //public void StartGame()
    //{
    //    SceneManager.LoadScene("main");
    //}

    private void Update()
    {
        if (BS != true)
        {
            if (Input.GetKeyDown("joystick button 1"))
            {
                SceneManager.LoadScene("main");
            }
        }
        BottonC();
        if (BS == true)
        {
            Cgm.SetActive(false);
            Cgms.SetActive(true);
        }
        else
        {
            if (BS == false)
            {
                Cgm.SetActive(true);
                Cgms.SetActive(false);
            }
        }
    }

    private void BottonC()
    {
        if (BS == false)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                BS = true;
            }
        }
        else
        {
            if (BS == true)
            {
                if (Input.GetKeyDown("joystick button 0"))
                {
                    BS = false;
                }
            }
        }
    }
}
