using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // create static singleton
    public static LevelController Instance { get; private set; }
    private int _barrels = 0;

    void Awake(){
        // initialise singleton instance
        if (Instance == null) Instance = this;
    }

    public void addBarrel(){
        ++_barrels;
        UIManager.Instance.UpdateBarrelDisplayUI(_barrels);

        if(_barrels == 3){
            UIManager.Instance.WinMessage();
            Time.timeScale = 0;
        }
    }
}
