using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    private void Update()
    {
        if (Input.GetKey("joystick button 1"))
        {
            SceneManager.LoadScene("main");
        }
    }
}
