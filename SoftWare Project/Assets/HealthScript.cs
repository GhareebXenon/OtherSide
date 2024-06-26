using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject Health;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] GameObject player;
    public float SpawnRate = 2f;
    float nextSpawn = 0.0f;

    public void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnRate;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(Health);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<BossEnemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }
    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;

        }

        position.z = 0;

        return position;
    }
}
