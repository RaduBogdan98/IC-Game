using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    //[SerializeField] private Transform respawnPoint;
    private GameMaster gm;
    private int passCounter;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        passCounter = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            passCounter++;
            if(passCounter == 1)
            {
                SoundManagerScript.PlaySound("sfx_sound_neutral9");
            }
            //respawnPoint.position = this.transform.position;
            gm.lastCheckPointPos = transform.position;
           // ProgressKeeper.SaveGame(this.transform.position);
            //Destroy(this.gameObject);
        }
    }
}
