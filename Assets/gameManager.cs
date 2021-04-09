using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerGameStates
{
    Alive,
    dead,

}

public class gameManager : MonoBehaviour
{
    private int score = 0;

    public PlayerGameStates PlayerGameStates;


    void Start()
    {
        PlayerGameStates = PlayerGameStates.Alive;
    }

    void Update()
    {
        
    }

    public void addScore(int add)
    {
        score += add;
    }
}
