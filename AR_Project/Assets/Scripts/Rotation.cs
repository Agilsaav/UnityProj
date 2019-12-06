using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0.0f, rotationSpeed*Time.deltaTime, 0.0f, Space.Self);  
    }
}
