using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioSource _audio;

    public AudioClip GameClearSE;
    public AudioClip GameOverSE;

    private void Start()
    {
        _audio = gameObject.AddComponent<AudioSource>();
    }
}
