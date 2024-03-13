using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsApply : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = new Options().MasterSound;
    }

}
