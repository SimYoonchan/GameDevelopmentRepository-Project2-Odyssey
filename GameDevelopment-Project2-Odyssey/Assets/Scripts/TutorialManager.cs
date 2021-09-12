using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialPopUps;
    private int tutorialPopUpsIndex;

    private float tutorialPurposefulDelay = 5f;

    //[SerializeField] GameObject ammoBonusSpawner;
    //[SerializeField] GameObject ammoSuperbonusSpawner;
    //[SerializeField] GameObject healthBonusSpawner;
    //[SerializeField] GameObject healthSuperbonusSpawner;

    [SerializeField] GameObject bonusSpawner;
    [SerializeField] GameObject superbonusSpawner;


    SceneLoader sceneLoader;
    //TutorialColliderCheck tutorialColliderCheck;

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
        //tutorialColliderCheck = GetComponent<TutorialColliderCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        TutorialPopUpSequence();
    }



    private void TutorialPopUpSequence()
    {
        for (int indexVariable = 0; indexVariable < tutorialPopUps.Length; indexVariable++) //This for loop doesn't seem to be doing what I want. It doesn't seem to make previous index go away or current one to appear.
        {
            if (indexVariable == tutorialPopUpsIndex)
            {
                tutorialPopUps[indexVariable].SetActive(true);
            }

            else
            {
                tutorialPopUps[indexVariable].SetActive(false);
            }
        }

        if (tutorialPopUpsIndex == 0)
        {
            //tutorialPopUps[0].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 1)
        {
            //tutorialPopUps[0].SetActive(false);
            //tutorialPopUps[1].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 2) //This is for moving tutorial.
        {
            //tutorialPopUps[1].SetActive(false);
            //tutorialPopUps[2].SetActive(true);

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) 
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 3) //This is for moving tutorial.
        {
            //tutorialPopUps[1].SetActive(false);
            //tutorialPopUps[2].SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 4)
        {
            //tutorialPopUps[3].SetActive(false);
            //tutorialPopUps[4].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 5) //This is for shooting tutorial.
        {
            //tutorialPopUps[4].SetActive(false);
            //tutorialPopUps[5].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }

        }

        else if (tutorialPopUpsIndex == 6) //This is for shooting tutorial.
        {
            //tutorialPopUps[4].SetActive(false);
            //tutorialPopUps[5].SetActive(true);

            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space))
            {
                tutorialPopUpsIndex++;
            }

        }

        else if (tutorialPopUpsIndex == 7) 
        {
            //tutorialPopUps[6].SetActive(false);
            //tutorialPopUps[7].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 8)
        {
            //tutorialPopUps[7].SetActive(false);
            //tutorialPopUps[8].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 9)
        {
            //tutorialPopUps[8].SetActive(false);
            //tutorialPopUps[9].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 10)
        {
            //tutorialPopUps[9].SetActive(false);
            //tutorialPopUps[10].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 11)
        {
            //tutorialPopUps[10].SetActive(false);
            //tutorialPopUps[11].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 12)
        {
            //tutorialPopUps[11].SetActive(false);
            //tutorialPopUps[12].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 13)
        {
            //tutorialPopUps[12].SetActive(false);
            //BonusSpawner.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 14)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 15)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 16)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 17)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 18)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 19)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 20)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 21)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 22)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tutorialPopUpsIndex++;
            }
        }

        else if (tutorialPopUpsIndex == 23)
        {
            //tutorialPopUps[13].SetActive(false);
            //tutorialPopUps[14].SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                sceneLoader.WonTutorialOntoLevel1();
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Health")
    //    {
    //        if (tutorialPopUpsIndex = 13)
    //        {

    //        }
    //    }
    //}

    //DON'T USE COROUTINES ON UPDATE METHOD AS THAT DOES NOT WORK.
    //private IEnumerator TutorialPopUpDelay()
    //{
    //    yield return new WaitForSeconds(betweenSomeTutorialPopupDelay);
    //}

    public void ResetGame() //We need this to destroy the Game Session object.
    {
        Destroy(gameObject);
    }
}


