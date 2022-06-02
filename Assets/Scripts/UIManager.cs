using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI barrelCounter;

    [SerializeField]
    private string winMessageText;
    [SerializeField]
    private TextMeshProUGUI winMessageTMProUI;

    private int _barrels = 0;

    public static UIManager Instance { get; private set; } // create static singleton
    public void UpdateBarrelDisplayUI(int barrels)
    {
        barrelCounter.text = "Barrels: " + barrels+ "/3"; 
    }

    public void WinMessage()
    {
        winMessageTMProUI.text = winMessageText; 
    }

    void Awake(){
        // initialise singleton instance
        if (Instance == null) Instance = this;
    } 

    // Start is called before the first frame update
    void Start()
    { 
        barrelCounter.text = "Barrels: 0/3";
    }
}
