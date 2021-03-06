using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // create static singleton
    public static LevelController Instance { get; private set; }
    private int _barrels = 0;
    private int _rotations = 0;
    private int _spaceJunk = 0;
    private int _spaceJunkTotal = 0;
    [SerializeField] private int _levelNumber = 1;
    [SerializeField] int threeStarRotations;
    [SerializeField] int twoStarRotations;
    [SerializeField] int oneStarRotations;
    [SerializeField] public SkinHolder skinsObject;

    void Awake(){
        // initialise singleton instance
        if (Instance == null) Instance = this;

        // set the players skin
        string selectedSkin = PlayerPrefs.GetString("selectedSkin");
        foreach(SkinObject skin in skinsObject.skins){
            if(skin.skinName == selectedSkin){
                GameObject respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
                GameObject player = Instantiate(skin.prefab, respawnPoint.transform.position, respawnPoint.transform.rotation, respawnPoint.transform);
            }
        }
    }

    void Start(){
        GameObject[] listOfSpaceJunk = GameObject.FindGameObjectsWithTag("SpaceJunk");
        _spaceJunkTotal = listOfSpaceJunk.Length;
    }

    public bool checkWin(){
        if(_barrels == 1){
            int stars = 0;
            
            if(_rotations <= threeStarRotations){
                stars = 3;
            }else if(_rotations <= twoStarRotations){
                stars = 2;
            }else if(_rotations <= oneStarRotations){
                stars = 1; 
            }

            UIManager.Instance.LevelCompletePopup(stars, 
            _rotations,
            _spaceJunk,
            _spaceJunkTotal,
            _levelNumber,
            oneStarRotations,
            twoStarRotations,
            threeStarRotations);

            // saves the level
            Save(stars);

            return true;
        }
        return false;
    }

    private void Save(int _stars){
        Level current = new Level();
        current.starCount = _stars;
        current.spaceJunk = _spaceJunk;
        current.levelNumber = _levelNumber;
        current.unlocked = true;
        Debug.Log(string.Format("{0}, {1}, {2}", _stars, _spaceJunk, _levelNumber));
        SaveLoad.Save(current);
    }

    public int getBarrelCount(){
        return _barrels;
    }

    public void addBarrel(){
        ++_barrels;
        UIManager.Instance.UpdateBarrelDisplayUI();
    }

    public int GetTotalSpaceJunk(){
        return _spaceJunkTotal;
    }

    public void AddSpaceJunk(){
        ++_spaceJunk;
        UIManager.Instance.UpdateSpaceJunkDisplayUI(_spaceJunk, _spaceJunkTotal);
    }

    public void addRotation(){
        _rotations++;
        UIManager.Instance.UpdateRotationsDisplayUI(_rotations);
    }
}
