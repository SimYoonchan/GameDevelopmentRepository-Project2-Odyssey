using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    //Config Param:
    [Header("Pause Menu Panels")]
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject instructionsUI;
    //public GameObject optionsSoundUI;

    [Header("Pause Menu Audio Mixer")]
    //[SerializeField] AudioMixer audioMixer;
    //[SerializeField] Slider masterVolumeSlider;
    //[SerializeField] TextMeshProUGUI masterVolumeSliderPercentageIndicator;
    //[SerializeField] Slider musicVolumeSlider;
    //[SerializeField] TextMeshProUGUI musicVolumeSliderPercentageIndicator;
    //[SerializeField] Slider storySoundEffectsVolumeSlider;
    //[SerializeField] TextMeshProUGUI storySoundEffectsVolumeSliderPercentageIndicator;
    //[SerializeField] Slider gameplaySoundEffectsVolumeSlider;
    //[SerializeField] TextMeshProUGUI gameplaySoundEffectsVolumeSliderPercentageIndicator;

    [Header("Pause Menu Audio")]
    public GameObject musicManager;
    [SerializeField] [Range(0, 1)] float musicManagerAudioController = 0f;
    public GameObject overarchingAudioManager;
    [SerializeField] [Range(0, 1)] float overarchingAudioManagerAudioController = 0f;
    public GameObject dialogueOrStoryTextManagerAudioManager;
    [SerializeField] [Range(0, 1)] float dialogueOrStoryTextManagerAudioManagerAudioController = 0f;

    //Cached References:
    SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        musicManager.GetComponent<AudioSource>().Play();
        overarchingAudioManager.GetComponent<AudioSource>().Play();
        dialogueOrStoryTextManagerAudioManager.GetComponent<AudioSource>().Play();

        pauseMenuUI.SetActive(false);
        instructionsUI.SetActive(false);
        //optionsSoundUI.SetActive(false);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        musicManager.GetComponent<AudioSource>().Pause();
        overarchingAudioManager.GetComponent<AudioSource>().Pause();
        dialogueOrStoryTextManagerAudioManager.GetComponent<AudioSource>().Pause();

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Instructions()
    {
        musicManager.GetComponent<AudioSource>().Pause();
        overarchingAudioManager.GetComponent<AudioSource>().Pause();
        dialogueOrStoryTextManagerAudioManager.GetComponent<AudioSource>().Pause();

        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        instructionsUI.SetActive(true);
    }

    public void BackFromInstructions()
    {
        musicManager.GetComponent<AudioSource>().Pause();
        overarchingAudioManager.GetComponent<AudioSource>().Pause();
        dialogueOrStoryTextManagerAudioManager.GetComponent<AudioSource>().Pause();

        instructionsUI.SetActive(false);
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void OptionsSound()
    {
        musicManager.GetComponent<AudioSource>().Pause();
        overarchingAudioManager.GetComponent<AudioSource>().Pause();
        dialogueOrStoryTextManagerAudioManager.GetComponent<AudioSource>().Pause();

        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        //optionsSoundUI.SetActive(true);
    }

    //public void SetMasterVolume(float volume)
    //{
    //    audioMixer.SetFloat("ChangeMasterVolumeThroughFloat", volume);

    //    //masterVolumeSlider.value = volume;

    //    float volumeToPercentageConversion = volume + 100; //Conversion: Because min is -100dB and max is 0 dB.
    //    masterVolumeSliderPercentageIndicator.text = volumeToPercentageConversion.ToString();
    //}

    //public void SetMusicVolume(float volume)
    //{
    //    audioMixer.SetFloat("ChangeMusicVolumeThroughFloat", volume);

    //    float volumeToPercentageConversion = volume + 100; //Conversion: Because min is -100dB and max is 0 dB.
    //    musicVolumeSliderPercentageIndicator.text = volumeToPercentageConversion.ToString();
    //}

    //public void SetStorySFXVolume(float volume)
    //{
    //    audioMixer.SetFloat("ChangeStorySFXVolumeThroughFloat", volume);

    //    float volumeToPercentageConversion = volume + 100; //Conversion: Because min is -100dB and max is 0 dB.
    //    storySoundEffectsVolumeSliderPercentageIndicator.text = volumeToPercentageConversion.ToString();
    //}

    //public void SetGameplaySFXVolume(float volume)
    //{
    //    audioMixer.SetFloat("ChangeGameplaySFXVolumeThroughFloat", volume);

    //    float volumeToPercentageConversion = volume + 100; //Conversion: Because min is -100dB and max is 0 dB.
    //    gameplaySoundEffectsVolumeSliderPercentageIndicator.text = volumeToPercentageConversion.ToString();
    //}

    //public void BackFromOptionsSound()
    //{
    //    musicManager.GetComponent<AudioSource>().Pause();
    //    overarchingAudioManager.GetComponent<AudioSource>().Pause();
    //    dialogueOrStoryTextManagerAudioManager.GetComponent<AudioSource>().Pause();

    //    //optionsSoundUI.SetActive(false);
    //    Time.timeScale = 0f;
    //    pauseMenuUI.SetActive(true);
    //}

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        sceneLoader.LoadStartScene();
    }

    public void BackToMainMenuFromTutorial()
    {
        Time.timeScale = 1f;
        sceneLoader.LoadStartSceneFromTutorial();
    }

    public void BackToMainMenuFromLevel1()
    {
        Time.timeScale = 1f;
        sceneLoader.LoadStartSceneFromLevel1();
    }

    public void BackToMainMenuFromLevel2Or3()
    {
        Time.timeScale = 1f;
        sceneLoader.LoadStartSceneFromLevel2Or3();
    }

    public void BackToMainMenuFromLevel4()
    {
        Time.timeScale = 1f;
        sceneLoader.LoadStartSceneFromLevel4();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
