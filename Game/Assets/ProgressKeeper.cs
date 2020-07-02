using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressKeeper : MonoBehaviour
{
    #region Methods
    public static void SaveGame(Vector3 RespawnPoint)
    {
        SaveData saveData = new SaveData
            (
                LivesScore.instance.GetCurrentNumberOfLives(),
                CoinScore.instance.GetCurrentNumberOfCoins(),
                SceneManager.GetActiveScene().buildIndex,
                new float[] { RespawnPoint.x, RespawnPoint.y, RespawnPoint.z }
            );

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.fox";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }
    #endregion
}
