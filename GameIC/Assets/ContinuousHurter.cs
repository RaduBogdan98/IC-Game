using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousHurter : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LivesScore.instance.ChangeScore(-1);
        }
    }
}
