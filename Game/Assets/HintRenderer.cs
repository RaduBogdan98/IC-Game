using System;
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
        actionQueue = new Queue<Action>();
    }

    #region Methods
    internal void RenderHint(string text)
    {
        if (HintMenu.activeInHierarchy == false)
        {
            hintText.text = text;
            HintMenu.SetActive(true);
        }
        else
        {
            actionQueue.Enqueue(() => RenderHint(text));
            Debug.Log("Added to queue " + text);
        }
    }

    public void CloseHint()
    {
        HintMenu.SetActive(false);
        Debug.Log(actionQueue.Count);
        if (actionQueue.Count != 0)
        {
            Debug.Log("Should Dequeue");
            actionQueue.Dequeue().Invoke();
        }
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

    private Queue<Action> actionQueue;
    private bool shouldRender = false;
    private string textToRender = "";
    #endregion
}
