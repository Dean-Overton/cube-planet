using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public ThemeLevelHolder themeObject;
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private GameObject lockedLevelPrefab;
    [SerializeField] private Transform scrollParent;
    private List<GameObject> levelButtons = new List<GameObject>();
    void Start()
    {
        // SaveLoad.Load();

        foreach(SceneObject sceneLevel in themeObject.levels) {
            GameObject go = Instantiate(levelPrefab, scrollParent);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = sceneLevel.levelNumber.ToString();
            SetGameObjectProgress(go, 0);

            // SetGameObjectProgress(go, SavedLoad.savedLevels[sceneLevel.levelNumber].progress);
            
            go.GetComponent<Button>().onClick.AddListener(
                delegate { SceneManagerScript.Instance.ChangeScene(sceneLevel.sceneName); }
            );

            levelButtons.Add(go);
        }
    }
    private void SetIndexProgress(int index, int starCount) {
        SetGameObjectProgress(scrollParent.GetChild(index).gameObject, starCount);
    }
    private void SetGameObjectProgress(GameObject go, int starCount) {
        int star = 0;
        foreach (Transform starObj in go.transform.GetChild(1))
            if (ColorUtility.TryParseHtmlString("D1D1D1", out Color newCol))
                starObj.GetComponent<Image>().color = newCol;

        while (star < starCount) {
            if (ColorUtility.TryParseHtmlString("D1D1D1", out Color newCol))
                go.transform.GetChild(1).GetChild(star).GetComponent<Image>().color = newCol;
            star++;
        }
    }
}
