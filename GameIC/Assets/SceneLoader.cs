using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        int levelToLoad = int.Parse(this.GetComponentInChildren<TextMeshProUGUI>().text);
        SceneManager.LoadScene(levelToLoad);
    }
}
