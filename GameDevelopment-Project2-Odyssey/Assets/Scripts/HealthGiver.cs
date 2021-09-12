using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGiver : MonoBehaviour
{
    [Header("Health Giving Info")]
    [SerializeField] float healthBonus;

    public float GiveHealth()
    {
        return healthBonus;
    }

    public void SuccessfulCollide()
    {
        Destroy(gameObject);
    }
}
