using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuPopulator : MonoBehaviour
{
    public GameObject levelButton;
    public float offsetX = 30;
    public float offsetY = 30;
    public float colDistance = 45;
    public float rowDistance = 44.5f;

    // Start is called before the first frame update
    void Start()
    {
        int scenesCount = SceneManager.sceneCountInBuildSettings;

        Debug.Log(scenesCount);

        int i = 0, j = 0;
        for (int sceneNumber = 1; sceneNumber < scenesCount; sceneNumber++)
        {
            Vector3 gridPosition = new Vector3((this.transform.localPosition.x + offsetX) + j * colDistance, (this.transform.localPosition.y + offsetY) - i * rowDistance, 0f);
            GameObject spawnedObj = Instantiate(levelButton) as GameObject;
            spawnedObj.transform.localScale = new Vector3(1, 1, 1);
            spawnedObj.transform.SetParent(this.transform, false);
            spawnedObj.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().SetText(sceneNumber.ToString());
            spawnedObj.transform.localPosition = gridPosition;

            if (j < 4)
            {
                j++;
            }
            else if (i < 3)
            {
                i++;
                j = 4;
            }
            else break;
        }
    }
}
