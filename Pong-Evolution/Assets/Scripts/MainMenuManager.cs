using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private float timeBetweenPowerupSpawn;
	[SerializeField] private List<GameObject> powerupPrefabs;
	[SerializeField] private GameObject ballPrefab;

	private float timeSinceLastPowerupSpawn;

    private void Start()
    {
        timeSinceLastPowerupSpawn = 0f;

		Instantiate(ballPrefab, Vector3.zero, Quaternion.identity).GetComponent<Ball>();
	}

    private void Update()
    {
		timeSinceLastPowerupSpawn += Time.deltaTime;

		if (timeSinceLastPowerupSpawn > timeBetweenPowerupSpawn)
		{
			SpawnPowerup();
			timeSinceLastPowerupSpawn = 0f;
		}
	}

	private void SpawnPowerup()
	{
		GameObject powerupToSpawn = powerupPrefabs[Random.Range(0, powerupPrefabs.Count)];
		Vector3 spawnLocation = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0);

		Instantiate(powerupToSpawn, spawnLocation, Quaternion.identity);
	}
}
