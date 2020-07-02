using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int sceneToLoad;

    internal void SetSceneToLoad(int sceneNumber)
    {
        sceneToLoad = sceneNumber;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
