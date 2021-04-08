using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuitScript : MonoBehaviour
{
    public void Quit()
    {
        print("Quit");
        Application.Quit();
    }
}
