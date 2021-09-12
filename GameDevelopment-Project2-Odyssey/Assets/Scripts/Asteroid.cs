using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Asteroid Health")]
    [SerializeField] float health;

    [Header("Asteroid Hit Flash")]
    [SerializeField] SpriteRenderer asteroidSpriteRendererVariable;
    [SerializeField] float hitFlashTime = 0.1f;

    [Header("Asteroid Explosion")]
    [SerializeField] GameObject explosionParticleSystem;
    [SerializeField] float explosionTimeDelay = 1f;
    [SerializeField] AudioClip[] explosionSFXArray;
    [SerializeField] [Range(0, 1)] float explosionSFXAudioController = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        asteroidSpriteRendererVariable.color = Color.red;
        yield return new WaitForSeconds(hitFlashTime);
        asteroidSpriteRendererVariable.color = Color.white;
    }

    private void Die()
    {
        //FindObjectOfType<GameSessionForLevel2And3>().AddToPlayerScore(enemyDeathScoresForPlayer);

        Destroy(gameObject);

        ExplosionSFX();
        StartCoroutine(DelayExplosionParticleSystem());
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
