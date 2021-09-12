using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeforeLevelPause : MonoBehaviour
{
    //Config Param:
    [Header("Before Level Pause UI")]
    [SerializeField] GameObject beforeLevelPauseUI;

    [Header("Before Level Pause Audio")]
    [SerializeField] GameObject musicManger;

    [Header("Disable Other Scripts")]
    [SerializeField] GameObject beforeLevelPauseScript;
    [SerializeField] GameObject playerShipScript;
    [SerializeField] GameObject pauseMenuScript;


    // Start is called before the first frame update
    void Start()
    {
        BeforeLevelPauseAtStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartPlayingLevel();
        }
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Return))
    //    {
    //        if (BeforeLevelPauseIsActive == false)
    //        {
    //            StartPlayingLevel();
    //        }
    //    }
    //}

    private void BeforeLevelPauseAtStart()
    {
        beforeLevelPauseUI.SetActive(true);
        beforeLevelPauseScript.GetComponent<BeforeLevelPause>().enabled = true;
        playerShipScript.GetComponent<PlayerShip>().enabled = false;
        pauseMenuScript.GetComponent<PauseMenu>().enabled = false;

        Time.timeScale = 0f;
    }

    private void StartPlayingLevel()
    {
        beforeLevelPauseUI.SetActive(false);
        beforeLevelPauseScript.GetComponent<BeforeLevelPause>().enabled = false;
        playerShipScript.GetComponent<PlayerShip>().enabled = true;
        pauseMenuScript.GetComponent<PauseMenu>().enabled = true;

        Time.timeScale = 1f;
    }
}
