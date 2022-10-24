using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 0.6f;

    // Ensures our level loader doesn't get destroyed between scene transitions.
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    //Allowing for both level names and indexes to be parsed to the level loader.
    public void LoadScene(int sceneIndex) {
        StartCoroutine(LoadLevel(SceneManager.GetSceneByBuildIndex(sceneIndex).name));
    }
    public void LoadScene(string sceneName) {
        StartCoroutine(LoadLevel(sceneName));
    }

    //Waits for transition to finish before loading the new scene.
    IEnumerator LoadLevel (string sceneName) {
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
