using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField][Range(0.1f, 120.0f)] float secondsBetweenSpawns = 2.0f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemies.text = score.ToString();
    }

    private IEnumerator RepeatedlySpawnEnemies()
    {
        while(true)
        {
            EnemyMovement newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            newEnemy.transform.parent = enemyParentTransform;
            AddScore();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
