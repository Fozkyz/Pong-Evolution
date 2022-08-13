using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenPowerupSpawn;

    [SerializeField] private List<GameObject> powerupPrefabs;

    private float timeSinceLastPowerupSpawn;

    private void Start()
    {
        timeSinceLastPowerupSpawn = 0f;
    }

    private void Update()
    {
        timeSinceLastPowerupSpawn += Time.deltaTime;

        if (timeSinceLastPowerupSpawn > timeBetweenPowerupSpawn)
        {
            SpawnPowerup();
        }
    }

    private void SpawnPowerup()
    {
        GameObject powerupToSpawn = powerupPrefabs[Random.Range(0, powerupPrefabs.Count)];
        // Instantiate at right place
    }
}
