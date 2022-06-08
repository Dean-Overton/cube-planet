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
        SaveLoad.Load();

        foreach(SceneObject sceneLevel in themeObject.levels) {
            GameObject go = Instantiate(levelPrefab, scrollParent);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = sceneLevel.levelNumber.ToString();
            // SetGameObjectProgress(go, 0);
            Level level = (Level)SaveLoad.savedLevels[sceneLevel.levelNumber];
            
            if(level == null){
                level = new Level();
                level.levelNumber = 0;
            }

            Debug.Log(level);

            SetGameObjectProgress(go, level);
            
            go.GetComponent<Button>().onClick.AddListener(
                delegate { SceneManagerScript.Instance.ChangeScene(sceneLevel.sceneName); }
            );

            levelButtons.Add(go);
        }
    }

    // private void SetIndexProgress(int index, int starCount) {
    //     SetGameObjectProgress(scrollParent.GetChild(index).gameObject, starCount);
    // }
    private void SetGameObjectProgress(GameObject go, Level level) {
        Debug.Log("Progress stars: "+level.starCount);
        
        int star = 0;
        foreach (Transform starObj in go.transform.GetChild(1))
            if (ColorUtility.TryParseHtmlString("D1D1D1", out Color newCol))
                starObj.GetComponent<Image>().color = newCol;

        while (star < level.starCount) {
            if (ColorUtility.TryParseHtmlString("F1DC06", out Color newCol))
                go.transform.GetChild(1).GetChild(star).GetComponent<Image>().color = newCol;
            star++;
        }
    }
}
