using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem goalParticle;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint>  path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach( Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        ParticleSystem vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();

        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
