using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Data", menuName = "Level/NewThemeLevelSet", order = 1)]
public class ThemeLevelHolder : ScriptableObject
{
    public string themeName;
    public Difficulty difficulty = Difficulty.EASY;
    public List<SceneObject> levels = new List<SceneObject>();
}
[System.Serializable]
public class SceneObject {
    public string sceneName;
    public int levelNumber;
}
public enum Difficulty {
    EASY,
    INTERMEDIATE,
    HARD
}