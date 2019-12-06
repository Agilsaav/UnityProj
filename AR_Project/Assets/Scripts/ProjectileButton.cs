using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ProjectileButton : MonoBehaviour, IVirtualButtonEventHandler
{
    [SerializeField] GameObject buttonObj;
    [SerializeField] float spawnTime = 10.0f; //Not Used
    [SerializeField] GameObject[] rockets;

    bool bShoot = true;

    void Start()
    {
        buttonObj = GameObject.Find("ShootButton");
        buttonObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Shoot();
        //StartCoroutine(SpawnRocket());
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
    }

    private void Shoot()
    {
        int number = Random.Range(0, 4);

        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Spaceship")
            {
                GameObject newRocket = Instantiate(rockets[number], transform.position, Quaternion.identity);
                newRocket.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
                newRocket.transform.parent = child.transform;

            }
        }

    }

    //Not Used.
    private IEnumerator SpawnRocket()
    {
        while (bShoot)
        {
            int number = Random.Range(0, 4);
            GameObject newRocket = Instantiate(rockets[number], transform.position, Quaternion.identity);
            newRocket.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
            newRocket.transform.parent = transform;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
