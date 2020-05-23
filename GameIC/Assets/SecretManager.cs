using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretManager : MonoBehaviour
{
    private void Start()
    {
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

    #region Fields
    [SerializeField] private GameObject Hider;
    [SerializeField] private GameObject Secret;
    #endregion
}
