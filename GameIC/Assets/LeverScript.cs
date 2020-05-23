using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(true == PlayerMovement.onFirstRun)
        {
            HintRenderer.Instance.RenderHint("To activate the lever press the E key!");
            PlayerMovement.onFirstRun = false;
        }

        if (collision.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Action"))
            {
                Debug.Log("E was pressed");
                spriteRenderer.flipX = true;
                SoundManagerScript.PlaySound("Rise03");
                SecretManager.Instance.exposeSecret();
            }
        }
    }
}
