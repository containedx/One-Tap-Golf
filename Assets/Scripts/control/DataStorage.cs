using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{
    public GameController gameController;

    public Text Score;
    public Text bestScore;

    [SerializeField]
    int score;
    [SerializeField]
    int bestscore;

    void Start()
    {
        Load();
        score = gameController.score;
    }

    void Update()
    {
        if(gameController.gameover)
        {
            score = gameController.score;
            Save();
            DisplayScore();
        }
    }


    void Load()
    {
        bestscore = PlayerPrefs.GetInt(Keys.BESTSCORE);
    }

    void Save()
    {
        SetBest();
        PlayerPrefs.SetInt(Keys.BESTSCORE, bestscore);
    }

    void SetBest()
    {
        if(score > bestscore)
        {
            bestscore = score;
        }
    }

    void DisplayScore()
    {
        Score.text = "YOUR SCORE: " + score.ToString();
        bestScore.text = "BEST SCORE: " + bestscore.ToString();
    }
}

public static class Keys
{
    public const string BESTSCORE = "BestScore";
}
