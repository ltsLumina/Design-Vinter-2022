using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    Player player;

    // reload scene when the player dies
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Load scene by index
    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

    // load next scene by hierarchy
    public void LoadNextScene()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // load next with delay
    public void LoadNextSceneWithDelay(float delay)
    {
        StartCoroutine(LoadNextScene(delay));
    }

    // reload scene
    public void ReloadScene()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // load next scene, but if the next scene is the last scene, load the first scene
    IEnumerator LoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);

        // if next scene is unavailable, debug.log-error that it is unavailable.
        if (nextSceneIndex == 0)
        {
            Debug.LogError("Next scene is unavailable");
        }
    }


}