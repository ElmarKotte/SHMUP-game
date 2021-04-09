using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private Scene currentScene;
    public void LoadLevelOne()
    {        
        SceneManager.LoadScene("LVL1");        
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Elmo test");
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadLevelFour()
    {
        SceneManager.LoadScene("");
    }
    public void LoadLevelFive()
    {
        SceneManager.LoadScene("");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void RestartCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
