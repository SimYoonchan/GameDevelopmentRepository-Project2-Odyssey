using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Delay-related")]
    //public float betweenScenePurposefulDelay = 0.55f;
    public float endOfSceneTransitionTime = 3f;


    [Header("Animators-related")]
    public Animator sceneTransitions;
    public Animator musicTransitions;
    public Animator overarchingBackgroundAudioTransitions;


    [Header("Button-related")]
    [SerializeField] AudioSource buttonClickSFX;


    private void Start()
    {
        buttonClickSFX = GetComponent<AudioSource>();
    }

    //public void LoadStartSceneAtMainMenu() //To call to go to Main Menu.
    //{
    //    //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //    //SceneManager.LoadScene(currentSceneIndex - currentSceneIndex);

    //    buttonClickSFX.Play();
    //    StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex));
    //}

    public void LoadStartScene() //To call to go to Main Menu.
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex - currentSceneIndex);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex));
    }

    public void GoToIntroStory() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 1));
    }

    public void GoToDreamStory() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 2);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 2));
    }

    public void GoToChapter1() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 3));
    }

    public void GoToTutorial() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 4));
    }

    public void GoToChapter2() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 5));
    }

    public void GoToLevel1() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 6));
    }

    public void GoToFlashbackStory() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 8));
    }

    public void GoToChapter3() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 9));
    }

    public void GoToChapter4() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 10));
    }

    public void GoToLevel2() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 11));
    }

    public void GoToChapter5() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 13));
    }

    public void GoToLevel3() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 14));
    }

    public void GoToChapter6() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 16));
    }

    public void GoToChapter7() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 17));
    }

    public void GoToLevel4() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 18));
    }

    public void GoToFinaleA() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 20));
    }

    public void GoToFinaleB() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 21));
    }

    public void GoToFinaleC() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 22));
    }

    public void GoToCredits() //To call when you click "New Game" in Main Menu. Only use this here.
    {
        //SceneManager.LoadScene(0 + 4);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(0 + 23));
    }

    //

    public void GoToNextScene() //To call whenver I need to go to the next scene.
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex +1);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadStartSceneFromTutorial() //Use this button for all "Go to Main Menu" from Level 1.
    {
        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex));
        FindObjectOfType<TutorialManager>().ResetGame();
    }

    public void WonTutorialOntoLevel1() //This works when you finish a level as there is a game over scene in between. So the next chapter can begin.
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex; 
        //SceneManager.LoadScene(currentIndex + 1);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex + 1));
        FindObjectOfType<TutorialManager>().ResetGame();
    }

    public void PlayLevelAgainForLevel1() //To call only at Game Over Scenes for level 1.
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentIndex - 1);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex - 1));
        FindObjectOfType<GameSessionSurviveTime>().ResetGame();
    }

    public void LoadStartSceneFromLevel1() //Use this button for all "Go to Main Menu" from Level 1.
    {
        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex));
        FindObjectOfType<GameSessionSurviveTime>().ResetGame();
    }

    public void WonLevel1OntoLevel2() //This works when you finish a level as there is a game over scene in between. So the next chapter can begin.
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex; 
        //SceneManager.LoadScene(currentIndex + 2);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex + 2));
        FindObjectOfType<GameSessionSurviveTime>().ResetGame();
    }

    public void PlayLevelAgainForLevel2or3() //To call only at Game Over Scenes for level 2.
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentIndex - 1);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex - 1));
        FindObjectOfType<GameSessionReachScore>().ResetGame();
    }

    public void LoadStartSceneFromLevel2Or3() //Use this button for all "Go to Main Menu" from Level 1.
    {
        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex));
        FindObjectOfType<GameSessionReachScore>().ResetGame();
    }

    public void WonLevel2Or3OntoLevel4() //This works when you finish a level as there is a game over scene in between. So the next chapter can begin.
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex; 
        //SceneManager.LoadScene(currentIndex + 2);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex + 2));
        FindObjectOfType<GameSessionReachScore>().ResetGame();
    }

    public void PlayLevelAgainForLevel4() //To call only at Game Over Scenes for level 2.
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentIndex - 1);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex - 1));
        FindObjectOfType<GameSessionDefeatBoss>().ResetGame();
    }

    public void LoadStartSceneFromLevel4() //Use this button for all "Go to Main Menu" from Level 1.
    {
        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex));
        FindObjectOfType<GameSessionDefeatBoss>().ResetGame();
    }

    public void WonLevel4RestartGameSession() //This works when you finish a level as there is a game over scene in between. So the next chapter can begin.
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex; 
        //SceneManager.LoadScene(currentIndex + 2);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex + 2));
        FindObjectOfType<GameSessionDefeatBoss>().ResetGame();
    }

    public void LoadGameOverForEachLevel() //This works as there is a Game Over scene for each level.
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentIndex + 1);

        buttonClickSFX.Play();
        StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void QuitGame() //To call to quit game.
    {
        buttonClickSFX.Play();
        Application.Quit();
    }

    IEnumerator LoadWithEndOfSceneTransitionAndMusicTransitionAndBackgroundSoundTransition(int currentSceneIndex) //This adds slight delay between scenes.
    {
        //1) Play animation
        if (sceneTransitions != null)
        {
            sceneTransitions.SetTrigger("TriggerEndOfSceneTransitionFade");
        }

        if (musicTransitions != null)
        {
            musicTransitions.SetTrigger("TriggerEndOfSceneMusicFade");
        }

        if (overarchingBackgroundAudioTransitions != null)
        {
            overarchingBackgroundAudioTransitions.SetTrigger("TriggerEndOfSceneOverarchingBackgroundAudioFade");
        }

        //2) Wait
        yield return new WaitForSeconds(endOfSceneTransitionTime);

        //3) Load Scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}