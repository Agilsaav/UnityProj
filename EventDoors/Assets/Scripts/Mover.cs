using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += (x * speed * transform.right * Time.deltaTime);
        transform.position += (y * speed * transform.forward * Time.deltaTime);
    }
}
