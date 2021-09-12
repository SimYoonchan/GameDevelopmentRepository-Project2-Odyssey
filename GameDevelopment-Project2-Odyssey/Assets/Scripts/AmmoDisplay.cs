using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    //Config Param:
    [Header("Ammo Display")]
    [SerializeField] TextMeshProUGUI playerAmmoCountDisplayHUD;


    //Cached References:
    PlayerShip playerShip;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = FindObjectOfType<PlayerShip>();
        playerAmmoCountDisplayHUD.text = playerShip.GetPlayerAmmoAmount().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerAmmoCountDisplayHUD.text = playerShip.GetPlayerAmmoAmount().ToString();
    }
}
