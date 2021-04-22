using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerGameStates
{
    Alive,
    dead,
}   

public class gameManager : MonoBehaviour
{
    private int score = 0;

    public PlayerGameStates PlayerGameStates;
    public Text scoreText;
    public Text finalScoreText;
    public Text highScoreText;


    void Start()
    {
        PlayerGameStates = PlayerGameStates.Alive;
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
    }

    void Update()
    {

    }

    public void addScore(int add)
    {
        score += add;
        scoreText.text = score.ToString();
    }
    public void SetScore(int set)
    {
        score = set;
        scoreText.text = score.ToString();
    }

    private void resetScore()
    {
        score = 0;
    }

    public void levelEnd(int level)
    {
        setHighScore(level);
        finalScoreText.text = score.ToString();
        highScoreText.text = getHighScore(level).ToString();
        resetScore();
    }
    private int getHighScore(int level)
    {
        string pref = "HighScoreLVL" + level;
        return PlayerPrefs.GetInt(pref);
    }
    private void setHighScore(int level)
    {
        string pref = "HighScoreLVL" + level;

        PlayerPrefs.SetInt(pref, Mathf.Max(score, PlayerPrefs.GetInt(pref)));
        print(PlayerPrefs.GetInt(pref));
    }
}
