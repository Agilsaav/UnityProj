using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyHitSFX);
    }

    private void KillEnemy()
    {
        ParticleSystem vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, vfx.main.duration);

        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position, 0.25f);

        Destroy(gameObject);
    }
}
