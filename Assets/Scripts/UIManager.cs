using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI barrelCounter;
    [SerializeField]
    private TextMeshProUGUI rotationsCounter;

    [SerializeField] private Animator levelCompletePopupAnimator;
    [SerializeField] private TMP_Text levelCompletePopupRotCount;
    [SerializeField] private TextMeshProUGUI winMessageTMProUI;

    public static UIManager Instance { get; private set; } // create static singleton
    public void UpdateBarrelDisplayUI(int barrels)
    {
        barrelCounter.text = "Barrels: " + barrels+ "/3"; 
    }

    public void UpdateRotationsDisplayUI(int rotations)
    {
        rotationsCounter.text = "Rotations: " + rotations; 
    }

    public void LevelCompletePopup(int stars, int rotations, int level)
    {
        levelCompletePopupAnimator.gameObject.SetActive(true);

        levelCompletePopupRotCount.text = "Rotations: " + rotations;

        winMessageTMProUI.text = string.Format("Nice Work! Level {0} Complete!", level); 
        levelCompletePopupAnimator.SetInteger("Stars", stars);
    }

    void Awake(){
        // initialise singleton instance
        if (Instance == null) Instance = this;
    } 

    public void RestartScene(){
        SceneManagerScript.Instance.RestartScene();
    }
    public void LoadLevelMenu(){
        SceneManagerScript.Instance.ChangeScene("MainMenu");
    }
    public void LoadNextLevel(){
        SceneManagerScript.Instance.LoadNextLevel();
    }

    // Start is called before the first frame update
    void Start()
    { 
        barrelCounter.text = "Barrels: 0/3";
        rotationsCounter.text = "Rotations: 0";
    }
}
