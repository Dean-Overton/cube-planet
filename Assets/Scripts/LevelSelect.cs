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
    void OnEnable()
    {
        SaveLoad.Load();

        foreach(GameObject levelButton in levelButtons){
            Destroy(levelButton);
        }

        foreach(SceneObject sceneLevel in themeObject.levels) {
            GameObject go = Instantiate(levelPrefab, scrollParent);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = sceneLevel.levelNumber.ToString();
            Level level = (Level)SaveLoad.savedLevels[sceneLevel.levelNumber];
            
            if(level == null){
                level = new Level();
                level.levelNumber = 1;
                Debug.Log("loaded level is null");
            }

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
        Color newCol;
        foreach (Transform starObj in go.transform.GetChild(1))
            if (ColorUtility.TryParseHtmlString("#D6DDE5", out newCol)){
                starObj.GetComponent<Image>().color = newCol;
            }

        
        while (star < level.starCount) {
            Debug.Log("nextstar");
            if(ColorUtility.TryParseHtmlString("#FFBF66", out newCol)){
                Debug.Log("changed colour");
                go.transform.GetChild(1).GetChild(star).GetComponent<Image>().color = newCol;
            }
            star++;
        }
    }
}
