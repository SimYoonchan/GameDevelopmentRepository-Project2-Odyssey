using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    [Header("Health Bonus Collide Audio")]
    [SerializeField] AudioClip[] healthBonusCollideSFXArray;
    [SerializeField] [Range(0, 1)] float healthBonusCollideSFXController = 0.25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SuccessfulHealthCollideSFX();
        }
    }

    void SuccessfulHealthCollideSFX()
    {
        AudioClip healthBonusCollideSFXVariable =
            healthBonusCollideSFXArray[UnityEngine.Random.Range(0, healthBonusCollideSFXArray.Length)];
        AudioSource.PlayClipAtPoint(
            healthBonusCollideSFXVariable,
            Camera.main.transform.position,
            healthBonusCollideSFXController);
    }
}
