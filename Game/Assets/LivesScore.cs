using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LivesScore : MonoBehaviour
{
    public static LivesScore instance;
    public TextMeshProUGUI text;
    public GameObject player;
    private int score=3;
    [SerializeField] private Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    internal int GetCurrentNumberOfLives()
    {
        return score;
    }

    // Update is called once per frame
    public void ChangeScore(int value)
    {
        score += value;
        text.text = score.ToString();

        if(score == 0)
        {
            player.transform.position = respawnPoint.position;
            ChangeScore(3);
        }
    }

    internal void SpawnPlayerWithScore(int livesScore, float[] position)
    {
        player.transform.position = new Vector3(position[0],position[1]);
        ChangeScore(livesScore);
    }
}
