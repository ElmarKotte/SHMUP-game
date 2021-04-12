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

    private void resetScore()
    {
        score = 0;
    }
    public void levelEnd(int level)
    {
        setHighScore(level);
        resetScore();
    }
    private void setHighScore(int level)
    {
        string pref = "HighScoreLVL" + level;

        PlayerPrefs.SetInt(pref, Mathf.Max(score, PlayerPrefs.GetInt(pref)));
        print(PlayerPrefs.GetInt(pref));
    }
}
