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
        print("LoadLevelOne");
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("LVL2");
        print("LoadLevelBOSS");
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene("LVL3");
        print("LoadLevelThree");
    }
    public void LoadLevelFour()
    {
        SceneManager.LoadScene("LVL4");
        print("LoadLevelFour");
    }
    public void LoadLevelFive()
    {
        SceneManager.LoadScene("LVL5");
        print("LoadLevelFive");

    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
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
