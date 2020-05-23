using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectableScript : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            SoundManagerScript.PlaySound("Powerup");
            LivesScore.instance.ChangeScore(value);
        }
    }
}
