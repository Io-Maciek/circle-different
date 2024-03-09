using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLooper : MonoBehaviour
{

    public AudioSource Audio1;
    public AudioSource Audio2;

    float _len = 16.0f;

    // Start is called before the first frame update
    void Start()
    {
        Audio1.loop = true;
        Audio1.Play();
        //StartCoroutine(_handle_music());
    }

    private IEnumerator _handle_music()
    {
        Debug.Log("TWORZE");
        Audio1.Play();
        Audio2.PlayDelayed(_len);
        yield return new WaitForSeconds(_len); // now audio2 starts playing
        yield return new WaitForSeconds(_len); // now loop to audio 1
        StartCoroutine(_handle_music());
        Debug.Log("Nowa rutyna");
    }
}
