using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CoinCollectableScript : MonoBehaviour
{
    public int value = 1;
  

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            CoinScore.instance.ChangeScore(value);
            SoundManagerScript.PlaySound("coin1");
        }
    }
}
