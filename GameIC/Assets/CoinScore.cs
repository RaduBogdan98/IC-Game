using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScore : MonoBehaviour
{
    public static CoinScore instance;
    public TextMeshProUGUI text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    internal int GetCurrentNumberOfCoins()
    {
        return score;
    }

    // Update is called once per frame
    public void ChangeScore(int value)
    {
        score += value;
        text.text = score.ToString();
    }
}
