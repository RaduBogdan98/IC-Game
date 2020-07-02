using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartScore : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public static int health;
    public static int numOfHearts;

    // public GameObject[] heart, emptyHeart;
    public GameObject gameOver;
    public GameObject player;
   
    [SerializeField] private Transform respawnPoint;
    private GameMaster gm;

    public IEnumerator Respawn(int p)
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }

        gameOver.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        numOfHearts = 3;
        health = 3;
    }

    void Start()
    {
        numOfHearts = 3;
        health = 3;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        gameOver.gameObject.SetActive(false);
    }
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        if(health == 0)
        {
            gameOver.gameObject.SetActive(true);
            StartCoroutine(Respawn(2));
        }        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }      
    }
            
}
