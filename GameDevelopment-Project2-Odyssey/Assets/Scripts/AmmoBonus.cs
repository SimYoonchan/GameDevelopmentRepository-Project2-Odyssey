using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBonus : MonoBehaviour
{
    [Header("Ammo Bonus Collide Audio")]
    [SerializeField] AudioClip[] ammoBonusCollideSFXArray;
    [SerializeField] [Range(0, 1)] float ammoBonusCollideSFXArrayController = 0.25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SuccessfulAmmoCollideSFX();
        }
    }

    private void SuccessfulAmmoCollideSFX()
    {
        AudioClip ammoBonusCollideSFXVariable =
            ammoBonusCollideSFXArray[UnityEngine.Random.Range(0, ammoBonusCollideSFXArray.Length)];
        AudioSource.PlayClipAtPoint(
            ammoBonusCollideSFXVariable,
            Camera.main.transform.position,
            ammoBonusCollideSFXArrayController);
    }
}
