using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
	[SerializeField] private float timeBetweenPowerupSpawn;
	[SerializeField] private List<GameObject> powerupPrefabs;

	private GameManager gameManager;

	private List<GameObject> spawnedPowerups;

	private float timeSinceLastPowerupSpawn;
	private bool isGameRunning;

	private void Start()
	{
		gameManager = GetComponent<GameManager>();
		gameManager.OnLaunchEvent.AddListener(OnLaunch);
		gameManager.OnGamePausedEvent.AddListener(OnGamePaused);
		gameManager.OnGameResumedEvent.AddListener(OnGameResumed);
		gameManager.OnLastBallScoredEvent.AddListener(OnLastBallScored);

		isGameRunning = false;
	}

	private void Update()
	{
		if (isGameRunning)
		{
			timeSinceLastPowerupSpawn += Time.deltaTime;

			if (timeSinceLastPowerupSpawn > timeBetweenPowerupSpawn)
			{
				SpawnPowerup();
				timeSinceLastPowerupSpawn = 0f;
				timeBetweenPowerupSpawn *= 1.2f;
			}
		}
	}

	private void SpawnPowerup()
	{
		GameObject powerupToSpawn = powerupPrefabs[Random.Range(0, powerupPrefabs.Count)];
		Vector3 spawnLocation = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0);

		GameObject spawnedPowerup = Instantiate(powerupToSpawn, spawnLocation, Quaternion.identity);
		spawnedPowerups.Add(spawnedPowerup);

		//Debug.Log("Spawning powerup at location : " + spawnLocation);
	}

	private void OnLaunch()
	{
		isGameRunning = true;
		timeSinceLastPowerupSpawn = 2f;
		spawnedPowerups = new List<GameObject>();
	}

	private void OnGamePaused()
	{
		isGameRunning = false;
	}

	private void OnGameResumed()
	{
		isGameRunning = true;
	}

	private void OnLastBallScored()
    {
		isGameRunning = false;
        foreach (GameObject powerup in spawnedPowerups)
        {
			Destroy(powerup);
        }
    }
}
