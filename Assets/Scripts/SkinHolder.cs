using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Level/NewSkinSet", order = 1)]
public class SkinHolder : ScriptableObject
{
    public List<SkinObject> skins = new List<SkinObject>();
}
[System.Serializable]
public class SkinObject {
    public string skinName;
    public int requiredStars;
    public int requiredSpaceJunk;
    
    // image
    public Sprite skinPreview;

    // actual skin prefab
    public GameObject prefab;
}