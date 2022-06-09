using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkinSelect : MonoBehaviour
{
    public ThemeLevelHolder themeObject;
    [SerializeField] private GameObject skinPrefab;
    [SerializeField] private GameObject lockedSkinPrefab;
    [SerializeField] private Transform scrollParent;
    private List<GameObject> skins = new List<GameObject>();
    void OnEnable()
    {
        SaveLoad.Load();

        foreach(GameObject skin in skins){
            Destroy(skin);
        }

        foreach(SceneObject sceneLevel in themeObject.levels) {
            Level level = (Level)SaveLoad.savedLevels[sceneLevel.levelNumber];
            GameObject go;
            
            if(level == null){
                level = new Level();
                level.levelNumber = sceneLevel.levelNumber;
                if(sceneLevel.levelNumber != 1){
                    level.unlocked = false;
                }else{
                    level.unlocked = true;
                    Level.current = level;
                }
            }

            if(level.unlocked){
                go = Instantiate(skinPrefab, scrollParent);
                // go.transform.GetChild(0).GetComponent<TMP_Text>().text = sceneLevel.levelNumber.ToString();
            
                // SetGameObjectProgress(go, level);
            
                // go.GetComponent<Button>().onClick.AddListener(
                //     delegate { SceneManagerScript.Instance.ChangeScene(sceneLevel.sceneName); }
                // );
            }else{
                go = Instantiate(lockedSkinPrefab, scrollParent);
            }

            skins.Add(go);
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
