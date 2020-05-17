using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
    }

    #region Methods
    internal void RenderHint(string text)
    {
        hintText.text = text;
        HintMenu.SetActive(true);
    }

    public void CloseHint()
    {
        HintMenu.SetActive(false);
    }
    #endregion

    #region Properties
    public static HintRenderer Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    #region Fields
    private static HintRenderer instance;
    public TextMeshProUGUI hintText;
    public GameObject HintMenu;
    #endregion
}
