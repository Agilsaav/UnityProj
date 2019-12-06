﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{

    [SerializeField] float restoreAngle = 90.0f;
    [SerializeField] float addIntensity = 1.0f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
