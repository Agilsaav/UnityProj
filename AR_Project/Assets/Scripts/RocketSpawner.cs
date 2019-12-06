using System.Collections;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 10.0f;
    [SerializeField] GameObject[] rockets;

    void Start()
    {
        StartCoroutine(SpawnRocket());
    }

    private IEnumerator SpawnRocket()
    {
        while (true)
        {
            int number = Random.Range(0, 4);
            GameObject newRocket = Instantiate(rockets[number], transform.position, Quaternion.identity);
            newRocket.transform.Rotate(0.0f, 90.0f, 90.0f, Space.Self);
            newRocket.transform.parent = transform;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
