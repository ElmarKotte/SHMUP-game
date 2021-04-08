using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayScript : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
    }
}
