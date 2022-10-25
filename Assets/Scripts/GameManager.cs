using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject goodSpherePrefab, badSherePrefab;
    public GameObject enemySpawnPoint, projectileSpawnPoint;
    public TextMeshProUGUI velocityField, angleField;

    public float enemySpawnSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner(enemySpawnSpeed));
        
    }

    public void Shoot()
    {
        Instantiate(goodSpherePrefab, projectileSpawnPoint.transform);
    }

    IEnumerator EnemySpawner(float waitTime)
    {
        //Do something before waiting.
        Instantiate(badSherePrefab, enemySpawnPoint.transform);

        //yield on a new YieldInstruction that waits for X seconds.
        yield return new WaitForSeconds(waitTime);

        //Do something after waiting.
        StartCoroutine(EnemySpawner(enemySpawnSpeed));
    }
}
