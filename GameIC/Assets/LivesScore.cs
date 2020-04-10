using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
}
