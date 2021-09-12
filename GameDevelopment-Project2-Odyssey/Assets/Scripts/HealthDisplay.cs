using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [Header("Player Health Count")]
    [SerializeField] TextMeshProUGUI playerHealthCountDisplayHUD;
    private float highHealthColourMin = 700f;
    private float middleHealthColourMin = 400f;


    PlayerShip playerShip;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = FindObjectOfType<PlayerShip>();
        playerHealthCountDisplayHUD.text = playerShip.GetPlayerHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HealthDisplayColorAndText();
    }

    void HealthDisplayColorAndText()
    {
        if (playerShip.GetPlayerHealth() >= highHealthColourMin)
        {
            playerHealthCountDisplayHUD.color = new Color(0.3178261f, 0.6603774f, 0.3021538f); //This is the 0 to 1 colour hue in RGB for the Green tint I want.
            playerHealthCountDisplayHUD.text = playerShip.GetPlayerHealth().ToString();
        }

        else if (playerShip.GetPlayerHealth() < highHealthColourMin && playerShip.GetPlayerHealth() >= middleHealthColourMin)
        {
            playerHealthCountDisplayHUD.color = Color.yellow;
            playerHealthCountDisplayHUD.text = playerShip.GetPlayerHealth().ToString();
        }

        else if (playerShip.GetPlayerHealth() < middleHealthColourMin)
        {
            playerHealthCountDisplayHUD.color = Color.red;
            playerHealthCountDisplayHUD.text = playerShip.GetPlayerHealth().ToString();
        }
    }
   
}
