using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        GameEventsManager.current.DoorwayTriggerEnter(id);
    }

    private void OnTriggerExit(Collider other)
    {
        GameEventsManager.current.DoorwayTriggerExit(id);
    }
}
