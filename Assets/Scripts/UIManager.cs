using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{   
    [SerializeField] private GameObject barrelCheck;
    [SerializeField] private TextMeshProUGUI rotationsCounter;
    [SerializeField] private TextMeshProUGUI spaceJunkCounter;
    [SerializeField] private TextMeshProUGUI levelCompletePopupStarCount1;
    [SerializeField] private TextMeshProUGUI levelCompletePopupStarCount2;
    [SerializeField] private TextMeshProUGUI levelCompletePopupStarCount3;
    [SerializeField] private Animator levelCompletePopupAnimator;
    [SerializeField] private TMP_Text levelCompletePopupRotCount;
    [SerializeField] private TMP_Text levelCompletePopupSpaceJunkCount;
    [SerializeField] private TextMeshProUGUI winMessageTMProUI;
    [SerializeField] private Animator levelPausePopupAnimator;
    [SerializeField] private Animator levelDeathPopupAnimator;

    public static UIManager Instance { get; private set; } // create static singleton
    public void UpdateBarrelDisplayUI()
    {
        barrelCheck.SetActive(true);
        SoundEffects.Instance.PlayCollectibleSound();
    }

    public void UpdateSpaceJunkDisplayUI(int spaceJunk, int total)
    {
        spaceJunkCounter.text = String.Format("{0}/{1}", spaceJunk, total);
        SoundEffects.Instance.PlayCollectibleSound();
    }

    public void UpdateRotationsDisplayUI(int rotations)
    {
        rotationsCounter.text = "Rotations: " + rotations; 
    }

    public void LevelCompletePopup(int stars, 
    int rotations, 
    int spaceJunk, 
    int spaceJunkTotal, 
    int level,
    int oneStar,
    int twoStar,
    int threeStar)
    {
        levelCompletePopupAnimator.gameObject.SetActive(true);
        SoundEffects.Instance.PlayWinSound();

        levelCompletePopupRotCount.text = "Rotations: " + rotations;

        levelCompletePopupSpaceJunkCount.text = String.Format("Space junk {0}/{1}", spaceJunk, spaceJunkTotal);

        levelCompletePopupStarCount1.text = String.Format("{0}", oneStar);
        levelCompletePopupStarCount2.text = String.Format("{0}", twoStar);
        levelCompletePopupStarCount3.text = String.Format("{0}", threeStar);

        winMessageTMProUI.text = string.Format("Nice Work! Level {0} Complete!", level); 
        levelCompletePopupAnimator.SetInteger("Stars", stars);
    }

    public void ShowPausePopup(){
        levelPausePopupAnimator.gameObject.SetActive(true);
        SoundEffects.Instance.PlayButtonClick();
    }

    public void ClosePausePopup(){
        levelPausePopupAnimator.gameObject.SetActive(false);
        SoundEffects.Instance.PlayButtonClick();
    }

    public void ShowDeathPopup(){
        levelDeathPopupAnimator.gameObject.SetActive(true);
    }

    void Awake(){
        // initialise singleton instance
        if (Instance == null) Instance = this;
    } 

    public void RestartScene(){
        SoundEffects.Instance.PlayButtonClick();
        SceneManagerScript.Instance.RestartScene();
    }
    public void LoadLevelMenu(){
        SoundEffects.Instance.PlayButtonClick();
        SceneManagerScript.Instance.ChangeScene("MainMenu");
    }
    public void LoadNextLevel(){
        SoundEffects.Instance.PlayButtonClick();
        SceneManagerScript.Instance.LoadNextLevel();
    }

    // Start is called before the first frame update
    void Start()
    {   
        rotationsCounter.text = "Rotations: 0";
        spaceJunkCounter.text = String.Format("0/{0}", LevelController.Instance.GetTotalSpaceJunk());
        SoundEffects.Instance.PlayGameMusic();
    }
}
