using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 5;
    [SerializeField] GameObject deathFX;

    ScoreBoard scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 0)
            KillEnemy();
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }

    private void KillEnemy()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
