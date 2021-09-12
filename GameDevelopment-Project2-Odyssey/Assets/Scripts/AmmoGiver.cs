using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGiver : MonoBehaviour
{
    [Header("Ammo Giving Info")]
    [SerializeField] float ammoRestockAmount;

    public float GiveAmmo()
    {
        return ammoRestockAmount;
    }

    public void SuccessfulCollide()
    {
        Destroy(gameObject);
    }
}
