using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SelectLevel()
    {

    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/save.fox";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log(data.LastCheckpointPosition);
            Debug.Log(data.SavedLivesScore);
            Debug.Log(data.SavedMoneyScore);
            Debug.Log(data.SavedSceneBuildIndex);

            SceneManager.LoadScene(data.SavedSceneBuildIndex);

            moneyScore = data.SavedMoneyScore;
            livesScore = data.SavedLivesScore;
            position = data.LastCheckpointPosition;
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }
        else
        {
            Debug.LogError("Save file not found");
        }
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        CoinScore.instance.ChangeScore(moneyScore);
        LivesScore.instance.SpawnPlayerWithScore(livesScore, position);
    }



    #region Fields
    private int moneyScore;
    private int livesScore;
    private float[] position;
    #endregion
}
