using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryText : MonoBehaviour
{
    [Header("Story-text-related")]
    public TextMeshProUGUI storyTextDisplay;
    //This connects the Story Text Box in Unity.

    [TextArea(10, 15)] public string[] sentences;
    //Array is like a container that holds lists of items in order.

    public int index;

    public float typingSpeed = 0.02f;


    [Header("Button-related")]
    public GameObject continueButtonNoBugging;
    //This connects the "Continue" button in Unity to be false (so not appear on screen) when we don't want it to be.
    //That also means that we can make it appear by saying true when we want it to be.

    public GameObject nextButtonForNextSceneNoBugging;
    //This connects the "Next" button in Unity to be false (so not appear on screen) when we don't want it to be.
    //That also means that we can make it appear by saying true when we want it to be.

    private AudioSource buttonClickSFX;
    //We will have to drop in this sound by Creating Component AudioSource.
    //This will be the StoryTextManager's only audio source and since we play it at the "ContinueStory()" method, it plays the audio.
    //And so we are just pairing it together while the button is being clicked to give the impression that button is making that sound.
    //This is different from giving the actual button some sounds and delaying the scene to hear the SFX.


        
    private void Start()
    {
        buttonClickSFX = GetComponent<AudioSource>();

        StartCoroutine(TypingOutStory());
        //The parameter is blank to allow whatever is in the parameter to be active as that can change based on the method we are in?

        //Since we clicked off "Continue" and "Next" button, we don't need to say that the SetActive(false) at the Start() method.
    }

    IEnumerator TypingOutStory()
    {
        foreach (char individualCharactersAndLetters in sentences[index].ToCharArray())
        {
            storyTextDisplay.text = storyTextDisplay.text + individualCharactersAndLetters; 
            yield return new WaitForSeconds(typingSpeed);
        }
    }   

    private void Update()
    {
        //Tip: Don't have the Calling of TypingOutStory in update as this makes it buggy.

        if (storyTextDisplay.text == sentences[index] & index < sentences.Length - 1)
        {
            continueButtonNoBugging.SetActive(true);
        }

        else
        {
            continueButtonNoBugging.SetActive(false);
        }

        if (index == sentences.Length - 1)
        {
            nextButtonForNextSceneNoBugging.SetActive(true);
        }

        else
        {
            nextButtonForNextSceneNoBugging.SetActive(false);
        }
    }

    public void ContinueStory()
    {
        continueButtonNoBugging.SetActive(false);
        buttonClickSFX.Play();

        if (index < sentences.Length - 1)
        {
            index++;
            storyTextDisplay.text = "";
            //We need this. Without it, the elements will keep typing in the same textbox without erasing the textbox and writing on a clean slate.
            //So in the " ", there is literally nothing in there, which is how we get a clean slate.
            StartCoroutine(TypingOutStory());
        }

        else
        {
            storyTextDisplay.text = "";
            continueButtonNoBugging.SetActive(false);
        }    
    }

    public void OntoNextScene()
    {
        //buttonClickSFX.Play(); //Block this as this is redundant as the sound is implemented in SceneLoader.cs file.

        if (index == sentences.Length - 1)
        {
            nextButtonForNextSceneNoBugging.SetActive(true);
            FindObjectOfType<SceneLoader>().GoToNextScene();
        }
        
        
    }
}
