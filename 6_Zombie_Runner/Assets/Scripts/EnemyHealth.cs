using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100.0f;

    bool isDead = false;

    public void TakeDamage(float damage)
    {
        //GetComponent<EnemyAI>().OnDamageTaken();  //Option 1
        BroadcastMessage("OnDamageTaken");          //Option 2

        hitPoints -= damage;

        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }

    public bool IsDead()
    {
        return isDead;
    }
}
