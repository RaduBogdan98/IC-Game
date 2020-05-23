using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover_sound : MonoBehaviour
{
    public AudioSource src;
    public AudioClip hover;
    public void HoverSound()
    {
        src.PlayOneShot(hover);
    }
}
