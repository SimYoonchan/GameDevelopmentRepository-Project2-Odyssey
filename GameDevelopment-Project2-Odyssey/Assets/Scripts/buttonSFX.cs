using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSFX : MonoBehaviour
{
    //Configuration Parameters:
    [Header("Button Audio Source")]
    public AudioSource myButtonSFXAudioSource;


    [Header("Button-hover-related")]
    [SerializeField] AudioClip[] buttonHoverSFX;


    //[Header("Button-click-related")]
    //[SerializeField] AudioClip[] buttonClickSFX; //I changed this to playing click sound as AudioSource.


    private void Start()
    {
        myButtonSFXAudioSource = GetComponent<AudioSource>();
        
    }

    public void buttonHoverSFXMethod() //This is for button hover.
    {
        AudioClip playButtonHoverSFX = buttonHoverSFX[UnityEngine.Random.Range(0, buttonHoverSFX.Length)];
        myButtonSFXAudioSource.PlayOneShot(playButtonHoverSFX);
    }

    //public void buttonClickSFXMethod() //This is for button click. //I changed this to playing click sound as AudioSource.
    //{
    //    AudioClip playButtonClickSFX = buttonClickSFX[UnityEngine.Random.Range(0, buttonClickSFX.Length)];
    //    myButtonSFXAudioSource.PlayOneShot(playButtonClickSFX);
    //}
}
