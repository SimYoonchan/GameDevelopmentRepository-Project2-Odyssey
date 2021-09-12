using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] float health;

    [Header("Enemy Shot Counter")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [Header("Enemy Projectile")]
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] float enemyProjectileSpeed = -20f; //We need to make this negative to make the enemy shoot in the opposite direction to player.
    [SerializeField] AudioClip[] enemyProjectileSFXArray;
    [SerializeField] [Range(0, 1)] float enemyProjectileSFXAudioController = 0.35f;

    [Header("Enemy Hit Flash")]
    [SerializeField] SpriteRenderer enemySpriteRendererVariable;
    [SerializeField] float hitFlashTime = 0.1f;
    private int flashAmount = 3;

    [Header("Enemy Explosion")]
    [SerializeField] GameObject explosionParticleSystem;
    [SerializeField] float explosionTimeDelay = 1f;
    [SerializeField] AudioClip[] explosionSFXArray;
    [SerializeField] [Range(0, 1)] float explosionSFXAudioController = 0.5f;

    [Header("Enemy Death Points For Player")]
    [SerializeField] int enemyDeathScoresForPlayer;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter = shotCounter - Time.deltaTime;

        if (shotCounter <= 0f)
        {
            EnemyFire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {
        if (gameObject.tag == "Enemy")
        {
            GameObject projectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyProjectileSpeed, 0);

            AudioClip enemyProjectileSFXArrayVariable = enemyProjectileSFXArray[UnityEngine.Random.Range(0, enemyProjectileSFXArray.Length)];
            AudioSource.PlayClipAtPoint(enemyProjectileSFXArrayVariable, Camera.main.transform.position, enemyProjectileSFXAudioController);
        }

        if (gameObject.tag == "Enemy Level 4")
        {
            GameObject projectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyProjectileSpeed, 0);

            AudioClip enemyProjectileSFXArrayVariable = enemyProjectileSFXArray[UnityEngine.Random.Range(0, enemyProjectileSFXArray.Length)];
            AudioSource.PlayClipAtPoint(enemyProjectileSFXArrayVariable, Camera.main.transform.position, enemyProjectileSFXAudioController);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>(); //We are getting the componet of the gameObject that is attached to the DamageDealer which is the projectiles.

        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);

        DestroyProjectiles(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health = health - damageDealer.GetDamage();
        StartCoroutine(HitFlash());

        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator HitFlash()
    {
        for (int i = 0; i < flashAmount; i++)
        {
            enemySpriteRendererVariable.color = Color.red;
            yield return new WaitForSeconds(hitFlashTime);
            enemySpriteRendererVariable.color = Color.white;
            yield return new WaitForSeconds(hitFlashTime);
        }
    }

    private void Die()
    {
        if (gameObject.tag == null)
        {
            return;
        }

        if (gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameSessionReachScore>().AddToPlayerScore(enemyDeathScoresForPlayer);

            Destroy(gameObject);

            ExplosionSFX();
            StartCoroutine(DelayExplosionParticleSystem());
        }

        else if (gameObject.tag == "Enemy Level 4")
        {
            Destroy(gameObject);

            ExplosionSFX();
            StartCoroutine(DelayExplosionParticleSystem());
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
}
