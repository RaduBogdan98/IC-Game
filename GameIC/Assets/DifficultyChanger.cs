using TMPro;
using UnityEngine;

public class DifficultyChanger : MonoBehaviour
{
    private TextMeshProUGUI difficultyValue;

    void Start()
    {

        difficultyValue = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeDifficulty()
    {
        switch (difficultyValue.text)
        {
            case "Baby boy": PlayerFollower.SetSeconds(60); break;
            case "Lad": PlayerFollower.SetSeconds(30); break;
            case "Life is hard": PlayerFollower.SetSeconds(20);  break;
            case "Death is near": PlayerFollower.SetSeconds(10); break;
        }
    }
}
