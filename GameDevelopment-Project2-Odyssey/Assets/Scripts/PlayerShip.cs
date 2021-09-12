using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    [Header("Player Ship Health")]
    [SerializeField] float playershipStartingHealth = 1000f;
    private float playershipCurrentHealth;
    private float minHealthToBeAtStartingHealthWithSuperHealth = 800f;
    [SerializeField] float healthHitFlashTime = 0.1f;
    private int healthHitFlashAmount = 3;

    [Header("Player Ship Ammo")]
    [SerializeField] float playershipStartingAmmoAmount = 20f;
    private float playershipCurrentAmmoAmount;
    [SerializeField] float playershipMaxAmmoAmount = 80f;
    private float minAmmoToBeAtMaxAmmoWithNormalAmmo = 60f; //Since normal ammo gives 10 ammo and max ammo is 80.
    private float minAmmoToBeAtMaxAmmoWithSuperAmmo = 40f; //Since super ammo gives 30 ammo and max ammo is 80.
    [SerializeField] float ammoHitFlashTime = 0.1f;
    private int ammoHitFlashAmount = 3;

    [Header("Player Ship Movement")]
    [SerializeField] float playershipMoveSpeed = 30f;

    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;

    [SerializeField] float playershipShapeXMin = 2f;
    [SerializeField] float playershipShapeXMax = -2f;
    [SerializeField] float playershipShapeYMin = 2f;
    [SerializeField] float playershipShapeYMax = -2f;

    [Header("Player Ship General Projectile")]
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    Coroutine fireContinouslyShotbigCoroutine;
    //Coroutine fireContinouslyRocketCoroutine;

    [Header("Player Ship Projectile Shotbig")]
    [SerializeField] GameObject playershipProjectileShotbig;
    [SerializeField] AudioClip[] playershipProjectileShotbigSFXArray;
    [SerializeField] [Range(0, 1)] float projectileShotbigSFXAudioController = 0.25f;

    //[Header("Player Ship Projectile Overheating")]
    //[SerializeField] Slider overheatSlider;
    //private float incShotVal = 2f;
    //private float decShotVal = 1f;
    //private float currentOverheatSlider = 0f;
    //private float maxOverheat = 20f;
    //private float noOverheat = 0f;

    [SerializeField] float overheatCooldownTime = 5f;
    public bool overheatCooldownIsHappening = false;
    [SerializeField] float shootHoldingTime = 5f;

    [Header("Player Ship Projectile Rocket")]
    [SerializeField] GameObject playershipProjectileRocket;
    [SerializeField] AudioClip[] playershipProjectileRocketSFXArray;
    [SerializeField] [Range(0, 1)] float projectileRocketSFXAudioController = 0.25f;

    [Header("Playe Ship Hit Flash")]
    public SpriteRenderer playershipSpriteRendererVariable;
    [SerializeField] float hitFlashTime = 0.1f;
    private int hitFlashAmount = 3;

    [Header("Playe Ship Hit Audio SFX")]
    [SerializeField] AudioClip[] playershipHitSFX;
    [SerializeField] [Range(0, 1)] float playershipHitSFXAudioController = 0.25f;

    [Header("Player Ship Explosion")]
    [SerializeField] GameObject explosionParticleSystem;
    [SerializeField] float explosionTimeDelay = 1f;
    [SerializeField] AudioClip[] explosionSFXArray;
    [SerializeField] [Range(0, 1)] float explosionSFXAudioController = 0.5f;

    [Header("Game Over Info")]
    [SerializeField] float gameOverTimeDelay = 1f;


    //Cached Reference:
    BeforeLevelPause beforeLevelPause;


    // Start is called before the first frame update
    void Start()
    {
        playershipMoveBoundaries();
        playershipCurrentHealth = playershipStartingHealth;
        playershipCurrentAmmoAmount = playershipStartingAmmoAmount;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerShipMove();
        PlayerShipFireShotbig();
        //PlayerShipFireRocket();
    }

    private void playershipMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    public void PlayerShipMove()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playershipMoveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playershipMoveSpeed;

        float newXPosition = Mathf.Clamp(transform.position.x + deltaX, xMin + playershipShapeXMin, xMax + playershipShapeXMax);
        float newYPosition = Mathf.Clamp(transform.position.y + deltaY, yMin + playershipShapeYMin, yMax + playershipShapeYMax);

        transform.position = new Vector2(newXPosition, newYPosition);
    }

    public void PlayerShipFireShotbig()
    {
        if (Input.GetButtonDown("Fire1") && playershipCurrentAmmoAmount > 0)
        {
            fireContinouslyShotbigCoroutine = StartCoroutine(FireContinouslyShotbig());
        }

        if (Input.GetButtonUp("Fire1") || playershipCurrentAmmoAmount <= 0)
        {
            StopCoroutine(fireContinouslyShotbigCoroutine);
        }
    }

    IEnumerator FireContinouslyShotbig()
    {
        while (true)
        {
            if (Time.time >= projectileFiringPeriod)
            {
                playershipCurrentAmmoAmount = playershipCurrentAmmoAmount - 1;
            }

            GameObject projectileShotbig = Instantiate(playershipProjectileShotbig, transform.position, Quaternion.identity) as GameObject;
            projectileShotbig.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);

            AudioClip projectileShotbigSFXArrayVariable =
                playershipProjectileShotbigSFXArray[UnityEngine.Random.Range(0, playershipProjectileShotbigSFXArray.Length)];
            AudioSource.PlayClipAtPoint(
                projectileShotbigSFXArrayVariable,
                Camera.main.transform.position,
                projectileShotbigSFXAudioController);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    //public void PlayerShipFireShotbig()
    //{
    //    if (overheatCooldownIsHappening == false)
    //    {
    //        if (Input.GetButtonDown("Fire1"))
    //        {
    //            fireContinouslyShotbigCoroutine = StartCoroutine(FireContinouslyShotbig());

    //            while (true)
    //            {
    //                overheatSlider.value = overheatSlider.value + incShotVal;

    //                if (overheatSlider.value >= maxOverheat)
    //                {
    //                    overheatCooldownIsHappening = true;
    //                }
    //            }
    //        }

    //        if (Input.GetButtonUp("Fire1"))
    //        {
    //            StopCoroutine(fireContinouslyShotbigCoroutine);

    //            while (overheatSlider.value > 0)
    //            {
    //                overheatSlider.value = overheatSlider.value - decShotVal *Time.deltaTime;
    //            }
    //        }
    //    }

    //    else if (overheatCooldownIsHappening == true)
    //    {
    //        if (Input.GetButtonDown("Fire1"))
    //        {
    //            StopCoroutine(fireContinouslyShotbigCoroutine);

    //            if (overheatSlider.value <= noOverheat)
    //            {
    //                overheatCooldownIsHappening = false;
    //            }
    //        }
    //    }
    //}

    //IEnumerator FireContinouslyShotbig()
    //{
    //    while (true)
    //    {
    //        GameObject projectileShotbig = Instantiate(playershipProjectileShotbig, transform.position, Quaternion.identity) as GameObject;
    //        projectileShotbig.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);

    //        AudioClip projectileShotbigSFXArrayVariable =
    //            playershipProjectileShotbigSFXArray[UnityEngine.Random.Range(0, playershipProjectileShotbigSFXArray.Length)];
    //        AudioSource.PlayClipAtPoint(
    //            projectileShotbigSFXArrayVariable,
    //            Camera.main.transform.position,
    //            projectileShotbigSFXAudioController);

    //        yield return new WaitForSeconds(projectileFiringPeriod);
    //    }
    //}

    //private void PlayerShipFireRocket()
    //{
    //    if (Input.GetButtonDown("Fire2"))
    //    {
    //        fireContinouslyRocketCoroutine = StartCoroutine(FireContinouslyRocket());
    //    }

    //    if (Input.GetButtonUp("Fire2"))
    //    {
    //        StopCoroutine(fireContinouslyRocketCoroutine);
    //    }
    //}

    //IEnumerator FireContinouslyRocket()
    //{
    //    while (true)
    //    {
    //        GameObject projectileRocket = Instantiate(playershipProjectileRocket, transform.position, Quaternion.identity) as GameObject;
    //        projectileRocket.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);

    //        AudioClip projectileRocketSFXArrayVariable =
    //            playershipProjectileRocketSFXArray[UnityEngine.Random.Range(0, playershipProjectileRocketSFXArray.Length)];
    //        AudioSource.PlayClipAtPoint(
    //            projectileRocketSFXArrayVariable,
    //            Camera.main.transform.position,
    //            projectileRocketSFXAudioController);

    //        yield return new WaitForSeconds(projectileFiringPeriod);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other) //This is code of what happens when something collides with the player ship.
    {
        if (other.tag == "Enemy")
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

            if (!damageDealer)
            {
                return;
            }

            ProcessHit(damageDealer); //This only takes the variable.

            StartCoroutine(HitFlash());
        }

        if (other.tag == "Enemy Projectile")
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

            if (!damageDealer)
            {
                return;
            }

            ProcessHit(damageDealer); //This only takes the variable.

            StartCoroutine(HitFlash());

            DestroyProjectiles(damageDealer);
        }

        if (other.tag == "Asteroid")
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

            if (!damageDealer)
            {
                return;
            }

            ProcessHit(damageDealer); //This only takes the variable.

            StartCoroutine(HitFlash());
        }

        else if (other.tag == "Health")
        {
            HealthGiver healthGiver = other.gameObject.GetComponent<HealthGiver>();

            if (!healthGiver)
            {
                return;
            }

            ProcessReceiveHealth(healthGiver); //This only takes the variable.

            StartCoroutine(HealthHitFlash());

            DestroyHealthBonus(healthGiver);
        }

        else if (other.tag == "Super Health")
        {
            HealthGiver healthGiver = other.gameObject.GetComponent<HealthGiver>();

            if (!healthGiver)
            {
                return;
            }

            ProcessReceiveSuperHealth(healthGiver); //This only takes the variable.

            StartCoroutine(HealthHitFlash());

            DestroyHealthBonus(healthGiver);
        }

        else if (other.tag == "Ammo")
        {
            AmmoGiver ammoGiver = other.gameObject.GetComponent<AmmoGiver>();

            if (!ammoGiver)
            {
                return;
            }

            ProcessReceiveAmmo(ammoGiver);

            StartCoroutine(AmmoHitFlash());

            DestroyAmmoBonus(ammoGiver);

        }

        else if (other.tag == "Super Ammo")
        {
            AmmoGiver ammoGiver = other.gameObject.GetComponent<AmmoGiver>();

            if (!ammoGiver)
            {
                return;
            }

            ProcessRecieveSuperAmmo(ammoGiver);

            StartCoroutine(AmmoHitFlash());

            DestroyAmmoBonus(ammoGiver);
        }    
    }

    private void ProcessHit(DamageDealer damageDealer) //This takes the type and the variable. The Type I believe is called "Local Variable"
    {
        playershipCurrentHealth = playershipCurrentHealth - damageDealer.GetDamage();

        AudioClip playershipHitSFXVariable = playershipHitSFX[(UnityEngine.Random.Range(0, playershipHitSFX.Length))];
        AudioSource.PlayClipAtPoint(playershipHitSFXVariable, Camera.main.transform.position, playershipHitSFXAudioController);
     
        if (playershipCurrentHealth <= 0)
        {
            playershipCurrentHealth = 0; //This ensure the health doesn't go into negatives.
            Die();
        }
    }

    private IEnumerator HitFlash()
    {
        for (int i = 0; i < hitFlashAmount; i++) //This helps it flash multiple times.
        {
            playershipSpriteRendererVariable.color = Color.red;
            yield return new WaitForSeconds(hitFlashTime);
            playershipSpriteRendererVariable.color = Color.white;
            yield return new WaitForSeconds(hitFlashTime); //We need to put the WaitForSeconds here or the colour will just stay one colour for the period of time and go back to normal.
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        ExplosionSFX();
        StartCoroutine(DelayExplosionParticleSystem());

        //StartCoroutine(DelayGameOver()); //The delay is already implemented in SceneLoader so adding this did nothing.
        DelayGameOver();
    }

    private void ExplosionSFX()
    {
        AudioClip explosionSFXVArrayVariable =
            explosionSFXArray[UnityEngine.Random.Range(0, explosionSFXArray.Length)];
        AudioSource.PlayClipAtPoint(
            explosionSFXVArrayVariable,
            Camera.main.transform.position,
            explosionSFXAudioController);
    }

    private IEnumerator DelayExplosionParticleSystem()
    {
        GameObject explosionParticleSystemVariable = Instantiate(
            explosionParticleSystem,
            transform.position,
            Quaternion.identity) as GameObject;

        yield return new WaitForSeconds(explosionTimeDelay);
    }

    //private IEnumerator DelayGameOver() //The delay is already implemented in SceneLoader so adding this did nothing.
    //{
    //    FindObjectOfType<SceneLoader>().LoadGameOverForEachLevel();
    //    yield return new WaitForSeconds(gameOverTimeDelay);
    //}

    private void DelayGameOver()
    {
        FindObjectOfType<SceneLoader>().LoadGameOverForEachLevel();
    }

    private void DestroyProjectiles(DamageDealer damageDealer)
    {
        damageDealer.Hit();
    }

    private void ProcessReceiveHealth(HealthGiver healthGiver) //This takes the type and the variable. The Type I believe is called "Local Variable"
    {
        if (playershipCurrentHealth >= playershipStartingHealth)
        {
            playershipCurrentHealth = playershipStartingHealth;
        }

        else
        {
            playershipCurrentHealth = playershipCurrentHealth + healthGiver.GiveHealth();
        }
    }

    private void ProcessReceiveSuperHealth(HealthGiver healthGiver) //This takes the type and the variable. The Type I believe is called "Local Variable"
    {
        if (playershipCurrentHealth >= minHealthToBeAtStartingHealthWithSuperHealth)
        {
            playershipCurrentHealth = playershipStartingHealth;
        }

        else
        {
            playershipCurrentHealth = playershipCurrentHealth + healthGiver.GiveHealth();
        }
    }

    private void ProcessReceiveAmmo(AmmoGiver ammoGiver)
    {
        if (playershipCurrentAmmoAmount > minAmmoToBeAtMaxAmmoWithNormalAmmo)
        {
            playershipCurrentAmmoAmount = playershipMaxAmmoAmount;
        }

        else
        {
            playershipCurrentAmmoAmount = playershipCurrentAmmoAmount + ammoGiver.GiveAmmo();
        }
    }

    private void ProcessRecieveSuperAmmo(AmmoGiver ammoGiver)
    {
        if (playershipCurrentAmmoAmount > minAmmoToBeAtMaxAmmoWithSuperAmmo)
        {
            playershipCurrentAmmoAmount = playershipMaxAmmoAmount;
        }

        else
        {
            playershipCurrentAmmoAmount = playershipCurrentAmmoAmount + ammoGiver.GiveAmmo();
        }
    }

    private IEnumerator HealthHitFlash()
    {
        for (int i = 0; i < healthHitFlashAmount; i++)
        {
            playershipSpriteRendererVariable.color = Color.green;
            yield return new WaitForSeconds(healthHitFlashTime);
            playershipSpriteRendererVariable.color = Color.white;
            yield return new WaitForSeconds(healthHitFlashTime);
        }
    }

    private void DestroyHealthBonus(HealthGiver healthGiver)
    {
        healthGiver.SuccessfulCollide();
    }

    public float GetPlayerHealth()
    {
        return playershipCurrentHealth;
    }

    private IEnumerator AmmoHitFlash()
    {
        for (int i = 0; i < ammoHitFlashAmount; i++)
        {
            playershipSpriteRendererVariable.color = Color.magenta;
            yield return new WaitForSeconds(ammoHitFlashTime);
            playershipSpriteRendererVariable.color = Color.white;
            yield return new WaitForSeconds(ammoHitFlashTime);
        }
    }

    public void DestroyAmmoBonus(AmmoGiver ammoGiver)
    {
        ammoGiver.SuccessfulCollide();
    }

    public float GetPlayerAmmoAmount()
    {
        return playershipCurrentAmmoAmount;
    }
}
