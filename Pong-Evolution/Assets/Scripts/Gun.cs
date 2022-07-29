using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType { NONE, FREEZING, DOWNSIZING}

public class Gun : MonoBehaviour
{
	[SerializeField] private GameObject freezingProjectileGO;
	[SerializeField] private GameObject downsizingProjectileGO;
	[SerializeField] private Transform shootTransform;

	[SerializeField] private int maxAmmunition;
	[SerializeField] private float cooldown;
	[SerializeField] private KeyCode shootKey;

	[SerializeField] private ProjectileType projectileType;

	private bool shootProjectileWhenReady;
	private float timeSinceLastShot;
	private int currentAmmunition;

    private void Start()
    {
		projectileType = ProjectileType.NONE;
		shootProjectileWhenReady = false;
		timeSinceLastShot = cooldown;
		currentAmmunition = maxAmmunition;
    }

    private void Update()
	{
		timeSinceLastShot += Time.deltaTime;

		if (Input.GetKey(shootKey))
        {
			if (timeSinceLastShot >= cooldown)
            {
				TryShoot();
				timeSinceLastShot = 0f;
				shootProjectileWhenReady = false;
            }
			else if (timeSinceLastShot >= cooldown * .75f)
            {
				shootProjectileWhenReady = true;
            }
        }
		if (shootProjectileWhenReady && timeSinceLastShot >= cooldown)
        {
			TryShoot();
			timeSinceLastShot = 0f;
			shootProjectileWhenReady = false;
        }
	}

	private void TryShoot()
    {
		if (currentAmmunition > 0)
        {
			Quaternion spawningRotation = shootTransform.position.x > transform.position.x ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
			switch (projectileType)
			{
				case ProjectileType.FREEZING:
					Instantiate(freezingProjectileGO, shootTransform.position, spawningRotation);
					break;

				case ProjectileType.DOWNSIZING:
					Instantiate(downsizingProjectileGO, shootTransform.position, spawningRotation);
					break;

				default:
					print(projectileType);
					// Play sound ?
					break;
			}
		}
		else
        {
			// Play sound ?
        }
		
    }

	public void SetProjectileType(ProjectileType type)
    {
		projectileType = type;
		currentAmmunition = maxAmmunition;
	}

	public void SetShootKey(KeyCode key)
    {
		shootKey = key;
    }
}
