using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(respawningBehaviour());
    }

    IEnumerator respawningBehaviour()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObject();
        }
    }

    private void spawnObject()
    {
        GameObject spawnedObj = Instantiate(objectPrefab) as GameObject;
        spawnedObj.transform.position = respawnPoint.transform.position;
    }
}
