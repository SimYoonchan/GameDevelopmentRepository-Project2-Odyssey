using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSessionSurviveTime : MonoBehaviour
{
    [Header("Time-related")]
    [SerializeField] float startingTime; //Write this in seconds.
    private float timer;
    [SerializeField] TextMeshProUGUI timeDisplayHUD;

    [Header("Victory-related")]
    [SerializeField] GameObject winLevelVictoryText;

    SceneLoader sceneLoader;
    PlayerShip playerShip;

    // Start is called before the first frame update

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

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        playerShip = FindObjectOfType<PlayerShip>();

        winLevelVictoryText.SetActive(false);

        StartCoroutine(CountdownTimer());
    }

    private IEnumerator CountdownTimer()
    {
        timer = startingTime;

        do
        {
            timer = timer - Time.deltaTime;
            FormatTime();
            yield return null;
        }
        while (timer > 0);
    }

    private void FormatTime()
    {
        //Strategy 1:
        //int days = (int)(timer / 86400) % 365;
        //int hours = (int)(timer / 3600) % 24;
        //int minutes = (int)(timer / 60) % 60;
        //int seconds = (int)(timer % 60);

        //timeDisplayHUD.text = ""; //Recall in the DialogueText.cs, basically the update of time countdown basicaly wipes it clean and sets the countdown each time so it provides the illusion that the time is reaching zero.

        //if (days > 0) { timeDisplayHUD.text = timeDisplayHUD.text + days + "d "; }
        //if (hours > 0) { timeDisplayHUD.text = timeDisplayHUD.text + hours + "h "; }
        //if (minutes > 0) { timeDisplayHUD.text = timeDisplayHUD.text + minutes + "m "; }
        //if (seconds > 0) { timeDisplayHUD.text = timeDisplayHUD.text + seconds + "s "; }


        //Strategy 2:
        //string days = ((int)(timer / 86400) % 365).ToString();
        //string hours = ((int)(timer / 3600) % 24).ToString();
        //string minutes = ((int)(timer / 60) % 60).ToString();
        //string seconds = ((int)(timer % 60)).ToString();

        //timeDisplayHUD.text = minutes + ":" + seconds;


        //Strategy 3:
        int days = (int)(timer / 86400) % 365;
        int hours = (int)(timer / 3600) % 24;
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);

        if (timer > 0) //Thus, in this strategy, we are only choosing to showcase minutes and seconds and ignoring days and hours.
        {
            timeDisplayHUD.text = minutes + ":" + seconds;

            if (seconds <= 9) { timeDisplayHUD.text = minutes + ":" + "0" + seconds; }
        }

        else if (timer <= 0 && playerShip.GetPlayerHealth() > 0)
        {
            WinLevel();
        }
    }

    private void WinLevel()
    {
        winLevelVictoryText.SetActive(true);
        sceneLoader.WonLevel1OntoLevel2();
    }

    public void ResetGame() //We need this to destroy the Game Session object.
    {
        Destroy(gameObject);
    }
}
