using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSessionDefeatBoss : MonoBehaviour
{
    Vex vex;
    SceneLoader sceneLoader;

    [Header("Vex Health")]
    [SerializeField] TextMeshProUGUI vexHealthDisplayHUD;

    [Header("Victory-related")]
    [SerializeField] float winningVexHealth = 0f;
    [SerializeField] GameObject winLevelVictoryText;


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
        vex = FindObjectOfType<Vex>();

        sceneLoader = FindObjectOfType<SceneLoader>();

        winLevelVictoryText.SetActive(false);

        vexHealthDisplayHUD.text = vex.GetVexHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        vexHealthDisplayHUD.text = vex.GetVexHealth().ToString();

        //if (vex.GetVexHealth() == 0)
        //{
        //    vexHealthDisplayHUD.text = vex.GetVexNoHealth().ToString();
        //}
    }

    public void WinLevel()
    {
        vexHealthDisplayHUD.text = winningVexHealth.ToString(); //This is shortcut way of making sure final score is always the winningScore.

        winLevelVictoryText.SetActive(true);
        sceneLoader.WonLevel4RestartGameSession();
    }

    public void ResetGame() //We need this to destroy the Game Session object.
    {
        Destroy(gameObject);
    }
}
