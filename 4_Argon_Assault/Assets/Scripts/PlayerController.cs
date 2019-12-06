using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controllSpeed = 10.0f;
    [Tooltip("In ms^-1")] [SerializeField] float xRange = 8.5f;
    [Tooltip("In ms^-1")] [SerializeField] float yRange = 4.5f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position Based")]
    [SerializeField] float PositionPitchFactor = -5.0f;
    [SerializeField] float PositionYawFactor = 7.0f;

    [Header("Control-throw Based ")]
    [SerializeField] float controlPitchFactor = -20.0f;
    [SerializeField] float controlRollFactor = -20.0f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controllSpeed * Time.deltaTime;
        float yOffset = yThrow * controllSpeed * Time.deltaTime;

        float XPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float YPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(XPos, YPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * PositionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * PositionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
            SetGunsActive(true);
        else
            SetGunsActive(false);
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

}
