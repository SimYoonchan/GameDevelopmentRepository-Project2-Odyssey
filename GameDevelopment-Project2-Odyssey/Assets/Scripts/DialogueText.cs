using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    [Header("Dialogue-text-related")]
    [SerializeField] TextMeshProUGUI dialogueTextsDisplay;
    [TextArea(10, 15)] [SerializeField] string[] dialogueSentencesArray;
    private int indexForDialogueSentencesDisplay;
    [SerializeField] float typingSpeed = 0.02f;


    [Header("Avatar-name-related")]
    [SerializeField] TextMeshProUGUI avatarNamesDisplay;
    [SerializeField] string[] avatarNamesArray;
    private int indexForAvatarNamesDisplay;


    [Header("Avatar-Head-Image-related")]
    [SerializeField] Image avatarHeadsDisplay;
    [SerializeField] Sprite[] avatarHeadsArray;
    private int indexForAvatarHeadsDisplay;


    [Header("Avatar-Voice-related")]
    [SerializeField] AudioSource avatarVoicesAndSoundsHearing;
    [SerializeField] AudioClip[] avatarVoicesAndSoundsArray;
    private int indexForAvatarVoicesAndSoundsHearing;
    [SerializeField] float DelayAvatarVoicesAndSounds = 1f;


    [Header("Story-Setting-Image-related")]
    [SerializeField] Image storySettingDisplay;


    [Header("Button-related")]
    [SerializeField] GameObject continueButtonNoBugging;
    [SerializeField] GameObject nextButtonForNextSceneNoBugging;
    [SerializeField] AudioSource buttonClickSFX; //Link to Main Camera.



    // Start is called before the first frame update
    void Start()
    {
        //No need to set continueButtonNoBugging or nextButtonForNextSceneNoBugging on SetActive(false) as they are checked off in Unity.
        //So they will be set as false at the start.

        buttonClickSFX = GetComponent<AudioSource>();
        //This initializes this variable. I need to drag in an audio source for the call to happen.

        avatarNamesDisplay.text = avatarNamesArray[indexForAvatarNamesDisplay];

        avatarHeadsDisplay.sprite = avatarHeadsArray[indexForAvatarHeadsDisplay];

        avatarVoicesAndSoundsHearing.clip = avatarVoicesAndSoundsArray[indexForAvatarVoicesAndSoundsHearing];
        StartCoroutine(DelayAvatarVoicesAndSoundsHearing());

        StartCoroutine(GetTypingOutDialogue());
    }

    private IEnumerator GetTypingOutDialogue()
    {
        foreach (char individualCharactersAndLetters in dialogueSentencesArray[indexForDialogueSentencesDisplay].ToCharArray())
        {
            dialogueTextsDisplay.text = dialogueTextsDisplay.text + individualCharactersAndLetters;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueTextsDisplay.text == dialogueSentencesArray[indexForDialogueSentencesDisplay] & indexForDialogueSentencesDisplay < dialogueSentencesArray.Length -1)
        {
            continueButtonNoBugging.SetActive(true);
        }

        else
        {
            continueButtonNoBugging.SetActive(false);
        }

        if (indexForDialogueSentencesDisplay == dialogueSentencesArray.Length - 1)
        {
            nextButtonForNextSceneNoBugging.SetActive(true);
        }

        else
        {
            nextButtonForNextSceneNoBugging.SetActive(false);
        }
    }

    

    public void ContinueDialogue()
    {
        continueButtonNoBugging.SetActive(false);
        buttonClickSFX.Play();

        if (indexForDialogueSentencesDisplay < dialogueSentencesArray.Length - 1)
        {
            indexForDialogueSentencesDisplay++;
            indexForAvatarNamesDisplay++;
            indexForAvatarHeadsDisplay++;
            indexForAvatarVoicesAndSoundsHearing++;

            dialogueTextsDisplay.text = "";

            avatarNamesDisplay.text = avatarNamesArray[indexForAvatarNamesDisplay];
            avatarHeadsDisplay.sprite = avatarHeadsArray[indexForAvatarHeadsDisplay];
            avatarVoicesAndSoundsHearing.clip = avatarVoicesAndSoundsArray[indexForAvatarVoicesAndSoundsHearing];
            StartCoroutine(DelayAvatarVoicesAndSoundsHearing());

            StartCoroutine(GetTypingOutDialogue());
        }

        else
        {
            dialogueTextsDisplay.text = ""; //To clear it up anyways.
            continueButtonNoBugging.SetActive(false);
        }
    }

    public void OntoNextScene()
    {
        //buttonClickSFX.Play(); //Block this as this is redundant.

        if (indexForDialogueSentencesDisplay == dialogueSentencesArray.Length - 1)
        {
            nextButtonForNextSceneNoBugging.SetActive(true);
            FindObjectOfType<SceneLoader>().GoToNextScene();
        }
    }

    IEnumerator DelayAvatarVoicesAndSoundsHearing()
    {
        yield return new WaitForSeconds(DelayAvatarVoicesAndSounds);
        avatarVoicesAndSoundsHearing.PlayOneShot(avatarVoicesAndSoundsHearing.clip);
    }
}
