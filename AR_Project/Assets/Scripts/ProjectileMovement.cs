using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] float lifeTime = 10.0f;

    GameObject target = null;
    Vector3 direction;
    float timeCount = 0.0f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            direction = target.transform.position - transform.position;
            //transform.LookAt(target.transform);
            Debug.Log("changing target");
        }
        else
        {
            Debug.Log("no target");
        }
    }

    void Update()
    {
        if (timeCount >= lifeTime) Die();
        //transform.Translate(direction * speed * Time.deltaTime);
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        timeCount += Time.deltaTime;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
