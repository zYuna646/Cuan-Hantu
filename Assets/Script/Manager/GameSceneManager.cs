using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { set; get; }
    // Start is called before the first frame update

     private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Method to load a scene by name
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Method to reload the current scene
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Method to load the next scene in the build order
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is within the valid range
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes to load!");
        }
    }

    // Method to load the previous scene in the build order
    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;

        // Check if the previous scene index is within the valid range
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("No previous scenes to load!");
        }
    }
}
