using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretManager : MonoBehaviour
{
    private SecretManager() { }

    private void Start()
    {
        if (instance == null) instance = this;
        Hider.SetActive(true);
        Secret.SetActive(false);

    }

    #region Methods
    internal void exposeSecret()
    {
        Hider.SetActive(false);
        Secret.SetActive(true);
    }
    #endregion

    #region Properties
    public static SecretManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    #region Fields
    [SerializeField] private GameObject Hider;
    [SerializeField] private GameObject Secret;
    private static SecretManager instance;
    #endregion
}
