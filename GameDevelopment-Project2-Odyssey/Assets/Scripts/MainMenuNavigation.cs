using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuNavigation : MonoBehaviour
{
    //Config Param:
    [Header("Game Object UI")]
    [SerializeField] GameObject mainMenuButtonsUI;
    [SerializeField] GameObject playChaptersUI;
    [SerializeField] GameObject instructionsUI;
    [SerializeField] GameObject optionsUI;

    [Header("Button-related")]
    [SerializeField] AudioSource buttonClickSFX;

    // Start is called before the first frame update
    void Start()
    {
        buttonClickSFX = GetComponent<AudioSource>();

        mainMenuButtonsUI.SetActive(true);
        playChaptersUI.SetActive(false);
        instructionsUI.SetActive(false);
        optionsUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayChaptersButtonPressed()
    {
        buttonClickSFX.Play();

        mainMenuButtonsUI.SetActive(false);
        playChaptersUI.SetActive(true);
    }

    public void BackfromPlayChapters()
    {
        buttonClickSFX.Play();

        mainMenuButtonsUI.SetActive(true);
        playChaptersUI.SetActive(false);
    }

    public void InstructionsButtonPressed()
    {
        buttonClickSFX.Play();

        mainMenuButtonsUI.SetActive(false);
        instructionsUI.SetActive(true);
    }

    public void BackfromInstructions()
    {
        buttonClickSFX.Play();

        mainMenuButtonsUI.SetActive(true);
        instructionsUI.SetActive(false);
    }

    public void OptionsButtonPressed()
    {
        buttonClickSFX.Play();

        mainMenuButtonsUI.SetActive(false);
        optionsUI.SetActive(true);
    }

    public void BackfromOptions()
    {
        buttonClickSFX.Play();

        mainMenuButtonsUI.SetActive(true);
        optionsUI.SetActive(false);
    }
}
