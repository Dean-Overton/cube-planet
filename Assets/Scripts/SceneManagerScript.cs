using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript Instance { get; private set; } // create static singleton
    
    private void Awake() {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void ChangeScene (int sceneIndex) {
        // TODO: Play Smooth Transition animation

        SceneManager.LoadScene(sceneIndex);
    }
    public void ChangeScene (string sceneName) {
        // TODO: Play Smooth Transition animation

        SceneManager.LoadScene(sceneName);
    }
}
