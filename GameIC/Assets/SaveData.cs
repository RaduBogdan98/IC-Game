using System;

[Serializable]
public class SaveData
{
    public SaveData(int lives, int money, int scene, float[] position)
    {
        SavedLivesScore = lives;
        SavedMoneyScore = money;
        SavedSceneBuildIndex = scene;
        LastCheckpointPosition = position;
    }

    #region Fields
    internal int SavedLivesScore;
    internal int SavedMoneyScore;
    internal int SavedSceneBuildIndex;
    internal float[] LastCheckpointPosition;
    #endregion
}
