using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManagerScript.PlaySound("sfx_sound_neutral9");
            respawnPoint.position = this.transform.position;
            ProgressKeeper.SaveGame(this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
