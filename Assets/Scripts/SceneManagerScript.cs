using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript Instance { get; private set; } // create static singleton

    [SerializeField] private LevelLoader levelLoaderInstance;

    private void Awake() {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    public void RestartScene(){
        levelLoaderInstance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel(){
        levelLoaderInstance.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void ChangeScene (int sceneIndex) {
        levelLoaderInstance.LoadScene(sceneIndex);
    }
    public void ChangeScene (string sceneName) {
        levelLoaderInstance.LoadScene(sceneName);
    }
}
