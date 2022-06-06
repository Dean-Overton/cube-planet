using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // create static singleton
    public static LevelController Instance { get; private set; }
    private int _barrels = 0;

    private int _rotations = 0;

    [SerializeField]
    int threeStarRotations;
    [SerializeField]
    int twoStarRotations;
    [SerializeField]
    int oneStarRotations;

    void Awake(){
        // initialise singleton instance
        if (Instance == null) Instance = this;
    }

    public bool checkWin(){
        if(_barrels == 3){
            int stars = 0;
            
            if(_rotations <= threeStarRotations){
                stars = 3;
            }else if(_rotations <= twoStarRotations){
                stars = 2;
            }else if(_rotations <= oneStarRotations){
                stars = 1; 
            }

            UIManager.Instance.LevelCompletePopup(stars, _rotations, 1);
            return true;
        }
        return false;
    }

    public int getBarrelCount(){
        return _barrels;
    }

    public void addBarrel(){
        ++_barrels;
        UIManager.Instance.UpdateBarrelDisplayUI(_barrels);
    }

    public void addRotation(){
        _rotations++;
        UIManager.Instance.UpdateRotationsDisplayUI(_rotations);
    }
}
