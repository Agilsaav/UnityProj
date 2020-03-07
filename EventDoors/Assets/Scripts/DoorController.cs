using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    
    void Start()
    {
        GameEventsManager.current.onDoorwayTriggerEnter += OnDoorwayOpen; //Subscribe the method in the event;
        GameEventsManager.current.onDoorwayTriggerExit += OnDoorwayClose;
    }

    private void OnDoorwayOpen(int id)
    {
        if(id == this.id) LeanTween.moveLocalY(gameObject, 1.4f, 1.0f).setEaseOutQuad();
    }

    private void OnDoorwayClose(int id)
    {
        if (id == this.id) LeanTween.moveLocalY(gameObject, 0.5f, 1.0f).setEaseInQuad();
    }

    private void OnDestroy()
    {
        GameEventsManager.current.onDoorwayTriggerEnter -= OnDoorwayOpen; //Unsubscribe the method in the event IMPORTANT;
        GameEventsManager.current.onDoorwayTriggerExit -= OnDoorwayClose;
    }
}
