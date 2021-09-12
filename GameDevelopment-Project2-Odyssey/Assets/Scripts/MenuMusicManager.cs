using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicManager : MonoBehaviour
{
    private static MenuMusicManager menuMusicInstancePrivate;

    public static MenuMusicManager menuMusicInstancePublic
    {
        get { return menuMusicInstancePrivate; }
    }


    public void Awake()
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex;

        if (menuMusicInstancePrivate != null && menuMusicInstancePrivate != this)
        {
            Destroy(gameObject);
            return;
        }

        else
        {
            menuMusicInstancePrivate = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    ////////////////////////////

    //[SerializeField] AudioSource mainMenuMusic;

    //public void Awake()
    //{
    //    mainMenuMusic = GetComponent<AudioSource>();
    //    mainMenuMusic.Play();

    //    SingletonMusicManager();
    //}

    //void SingletonMusicManager()
    //{
    //    int currentIndex = SceneManager.GetActiveScene().buildIndex;

    //    if (FindObjectsOfType(GetType()).Length > 1)
    //    {
    //        if (currentIndex > 3)
    //        {
    //            Destroy(gameObject);
    //        }
    //    }

    //    else
    //    {
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}
}