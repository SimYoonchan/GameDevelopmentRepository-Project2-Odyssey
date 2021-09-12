using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vex : MonoBehaviour
{
    //Cached Reference:
    SceneLoader sceneLoader;
    PlayerShip playerShip;
    GameSessionDefeatBoss gameSessionDefeatBoss;


    //Config Param:
    [Header("Vex Health")]
    [SerializeField] float vexHealth;
    private float stageTwoVexHealth;

    //[Header("Vex Animation")]
    //private Animator vexAnimation;

    [Header("Vex Shot Counter")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 1.5f;
    [SerializeField] float maxTimeBetweenShots = 4.5f;

    [Header("Vex Projectile")]
    [SerializeField] GameObject vexProjectile;
    [SerializeField] float vexProjectileSpeed = -60f; //We need to make this negative to make the enemy shoot in the opposite direction to player.
    [SerializeField] AudioClip[] vexProjectileSFXArray;
    [SerializeField] [Range(0, 1)] float vexProjectileSFXAudioController = 0.35f;

    [Header("Vex Hit Flash")]
    [SerializeField] SpriteRenderer vexSpriteRendererVariable;
    [SerializeField] float hitFlashTime = 0.1f;
    //private int flashAmount = 3;

    [Header("Vex Explosion")]
    [SerializeField] GameObject explosionParticleSystem;
    [SerializeField] float explosionTimeDelay = 1f;
    [SerializeField] AudioClip[] explosionSFXArray;
    [SerializeField] [Range(0, 1)] float explosionSFXAudioController = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        playerShip = FindObjectOfType<PlayerShip>();
        gameSessionDefeatBoss = FindObjectOfType<GameSessionDefeatBoss>();

        stageTwoVexHealth = vexHealth / 2; //MUST MAKE CHANGE HERE IF WE WANT STAGE TWO TO OCCUR AT ANOTHER POINT.

        //vexAnimation = GetComponent<Animator>();

        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        VexCountDownAndShoot(); 
    }

    public void VexCountDownAndShoot()
    {
        shotCounter = shotCounter - Time.deltaTime;

        if (shotCounter <= 0f)
        {
            VexFire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    public void VexFire()
    {
        GameObject projectile = Instantiate(vexProjectile, transform.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(vexProjectileSpeed, 0);

        AudioClip enemyProjectileSFXArrayVariable = vexProjectileSFXArray[UnityEngine.Random.Range(0, vexProjectileSFXArray.Length)];
        AudioSource.PlayClipAtPoint(enemyProjectileSFXArrayVariable, Camera.main.transform.position, vexProjectileSFXAudioController);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Player Projectile")
        //{
        //    DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        //    if (!damageDealer)
        //    {
        //        return;
        //    }

        //    ProcessHit(damageDealer);

        //    DestroyProjectiles(damageDealer);
        //}

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);

        DestroyProjectiles(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        vexHealth = vexHealth - damageDealer.GetDamage();

        StartCoroutine(DelayExplosionParticleSystem());

        //StartCoroutine(HitFlash());

        //if (vexHealth <= stageTwoVexHealth)
        //{
        //    VexStageTwoAnimation();
        //}

        if (vexHealth <= 0)
        {
            Die();
        }
    }

    //private void VexStageTwoAnimation()
    //{
    //    vexAnimation.SetTrigger("StageTwo");
    //    vexAnimation.ResetTrigger("StageTwo");
    //}

    //private IEnumerator HitFlash()
    //{
    //    for (int i = 0; i < flashAmount; i++)
    //    {
    //        vexSpriteRendererVariable.color = Color.red;
    //        yield return new WaitForSeconds(hitFlashTime);
    //        vexSpriteRendererVariable.color = Color.white;
    //        yield return new WaitForSeconds(hitFlashTime);
    //    }
    //}

    private void Die()
    {
        Destroy(gameObject);

        ExplosionSFX();
        StartCoroutine(DelayExplosionParticleSystem());

        if (playerShip.GetPlayerHealth() > 0 && vexHealth <= 0)
        {
            gameSessionDefeatBoss.WinLevel();
        }
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

    private void DestroyProjectiles(DamageDealer damageDealer)
    {
        damageDealer.Hit();
    }

    public float GetVexHealth()
    {
        return vexHealth;
    }

    public float GetVexHalfHealth()
    {
        return stageTwoVexHealth;
    }
}
