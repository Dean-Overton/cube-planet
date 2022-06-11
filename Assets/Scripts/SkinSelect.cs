using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkinSelect : MonoBehaviour
{
    public SkinHolder skinsObject;
    [SerializeField] private GameObject skinPrefab;
    [SerializeField] private GameObject lockedSkinPrefab;
    [SerializeField] private Transform scrollParent;
    private List<GameObject> skins = new List<GameObject>();
    private static int selectedSkinIndex;
    void OnEnable()
    {
        SaveLoad.Load();

        // get stars and spaceJunk counts
        int stars = SaveLoad.collectedStarsTotal;
        int spaceJunk = SaveLoad.collectedSpaceJunkTotal;

        // display these values in UI
        transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = stars.ToString();
        transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = spaceJunk.ToString();

        foreach(GameObject skin in skins){
            Destroy(skin);
        }

        string selectedSkin = PlayerPrefs.GetString("selectedSkin");
        Debug.Log(selectedSkin);

        foreach(SkinObject skin in skinsObject.skins) {
            GameObject go;

            if(skin.requiredStars <= stars && skin.requiredSpaceJunk <= spaceJunk){
                go = Instantiate(skinPrefab, scrollParent);
                
                go.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = skin.skinPreview;

                if(skin.skinName == selectedSkin){
                    go.transform.GetChild(0).gameObject.SetActive(true);
                }

                // add the ability to actually select the skin
                go.GetComponent<Button>().onClick.AddListener(
                    delegate {
                        PlayerPrefs.SetString("selectedSkin", skin.skinName);
                        SoundEffects.Instance.PlayButtonClick();
                        // just recalls this methods to refresh entire UI
                        OnEnable();
                        }
                );
            }else{
                go = Instantiate(lockedSkinPrefab, scrollParent);

                if(skin.requiredStars == 0){
                    go.transform.GetChild(3).gameObject.SetActive(false);
                }else{
                    go.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = skin.requiredStars.ToString();
                }
                
                if(skin.requiredSpaceJunk == 0){
                    go.transform.GetChild(4).gameObject.SetActive(false);
                }else{
                    go.transform.GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = skin.requiredSpaceJunk.ToString();
                }
            }

            // set name of skin
            go.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = skin.skinName.ToString();

            skins.Add(go);
        }
    }
}
