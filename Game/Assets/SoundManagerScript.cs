using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip coinPickUpSound, playerJump, heartSound, leverSound, monster1Hit, monster2Hit, monsterDeath, playerhurt, checkpoint;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        coinPickUpSound = Resources.Load<AudioClip>("coin1");
        playerJump = Resources.Load<AudioClip>("Jump");
        heartSound = Resources.Load<AudioClip>("Powerup");
        leverSound = Resources.Load<AudioClip>("Rise03");
        monster1Hit = Resources.Load<AudioClip>("monster-3");
        monsterDeath = Resources.Load<AudioClip>("monster_death");
        monster2Hit = Resources.Load<AudioClip>("monster-7");
        playerhurt = Resources.Load<AudioClip>("sfx_sounds_impact5");
        checkpoint = Resources.Load<AudioClip>("sfx_sound_neutral9");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coin1":
                audioSrc.clip = coinPickUpSound;
                audioSrc.volume = 0.5f;
                audioSrc.Play();
                break;
            case "Jump":
                audioSrc.clip = playerJump;
                audioSrc.volume = 0.2f;
                audioSrc.Play();
                break;
            case "Powerup":
                audioSrc.clip = heartSound;
                audioSrc.volume = 0.5f;
                audioSrc.Play();
                break;
            case "Rise03":
                audioSrc.clip = leverSound;
                audioSrc.volume = 0.5f;
                audioSrc.Play();
                break;
            case "monster1":
                audioSrc.clip = monster1Hit;
                audioSrc.volume = 0.5f;               
                audioSrc.Play();
                break;
            case "monster2":
                audioSrc.clip = monster2Hit;
                audioSrc.volume = 0.5f;
                audioSrc.Play();
                break;
            case "sfx_sounds_impact5":
                audioSrc.clip = playerhurt;
                audioSrc.volume = 0.5f;
                audioSrc.Play();
                break;
            case "sfx_sound_neutral9":
                audioSrc.clip = checkpoint;
                audioSrc.volume = 0.5f;
                audioSrc.Play();
                break;

        }
    }
}
