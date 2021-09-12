using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MenuMusicManager.menuMusicInstancePublic.gameObject.GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
