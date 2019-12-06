using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomOutFOV = 60.0f;
    [SerializeField] float zoomInFOV = 20.0f;
    [SerializeField] float zoomOutSensitivity = 2.0f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    bool zoomedInToggle = false;

    private void OnDisable()
    {
        fpsCamera.fieldOfView =  zoomOutFOV;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void Update()
    {
        fpsCamera.fieldOfView = Input.GetMouseButton(1) ? zoomInFOV : zoomOutFOV;
        fpsController.mouseLook.XSensitivity = Input.GetMouseButton(1) ? zoomInSensitivity : zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = Input.GetMouseButton(1) ? zoomInSensitivity : zoomOutSensitivity;

        //if(Input.GetButton("Fire2"))
        //{
        //    if(zoomedInToggle == false)
        //    {
        //        zoomedInToggle = true;
        //        fpsCamera.fieldOfView = zoomInFOV;
        //        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        //        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
        //    }
        //    else
        //    {
        //        zoomedInToggle = false;
        //        fpsCamera.fieldOfView = zoomOutFOV;
        //        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        //        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
        //    }
        //}
    }

}
