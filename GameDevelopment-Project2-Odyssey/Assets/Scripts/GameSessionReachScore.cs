using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSessionReachScore : MonoBehaviour
{
    [Header("Score-related")]
    [SerializeField] int playerScore = 0; //Will initialize at zero to start.
    [SerializeField] TextMeshProUGUI playerScoreCountDisplayHUD;
    [SerializeField] int winningScore;
    [SerializeField] TextMeshProUGUI winningScoreDisplayHUD;

    [Header("Victory-related")]
    [SerializeField] GameObject winLevelVictoryText;

    SceneLoader sceneLoader;

    private void Awake()
    {
        SingletonGameSession();
    }

    void SingletonGameSession()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        playerScoreCountDisplayHUD.text = playerScore.ToString();

        winningScoreDisplayHUD.text = winningScore.ToString();

        winLevelVictoryText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreCountDisplayHUD.text = playerScore.ToString();
    }

    public void AddToPlayerScore(int enemyDeathScoresForPlayer) //Argument must be passed in here so that method knows what to add.
    {
        playerScore = playerScore + enemyDeathScoresForPlayer;

        if (playerScore >= winningScore)
        {
            WinLevel();
        }
    }

    private void WinLevel()
    {
        playerScoreCountDisplayHUD.text = winningScore.ToString(); //This is shortcut way of making sure final score is always the winningScore.

        winLevelVictoryText.SetActive(true);
        sceneLoader.WonLevel2Or3OntoLevel4();
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void ResetGame() //We need this to destroy the Game Session object.
    {
        Destroy(gameObject);
    }
}
