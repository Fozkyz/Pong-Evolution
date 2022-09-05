using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private float timeBetweenPowerupSpawn;
	[SerializeField] private List<GameObject> powerupPrefabs;
	[SerializeField] private GameObject ballPrefab;

	[SerializeField] private GameObject lPowerupSpawner, rPowerupSpawner;

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
		if (Random.Range(0, 2) < .5f)
        {
			Vector3 spawnLocation = new Vector3(Random.Range(3f, 8f), Random.Range(-4f, 1f), 0);
			Instantiate(powerupToSpawn, spawnLocation, Quaternion.identity);
        }
		else
        {
			Vector3 spawnLocation = new Vector3(Random.Range(-8f, -3f), Random.Range(-4f, 1f), 0);
			Instantiate(powerupToSpawn, spawnLocation, Quaternion.identity);
        }
	}

	public void PlaySingleplayer()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
