using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressKeeper : MonoBehaviour
{
    private ProgressKeeper()
    {
       
    }

    #region Methods
    public static ProgressKeeper getInstance()
    {
        if(null == instace)
        {
            instace = new ProgressKeeper();
        }

        return instace;
    }

    public void SaveState()
    {
        SavedLivesScore = LivesScore.instance.GetCurrentNumberOfLives();
        SavedMoneyScore = CoinScore.instance.GetCurrentNumberOfCoins();
    }
    #endregion

    #region Fields
    public static ProgressKeeper instace;
    public int SavedLivesScore;
    public int SavedMoneyScore;
    #endregion
}
