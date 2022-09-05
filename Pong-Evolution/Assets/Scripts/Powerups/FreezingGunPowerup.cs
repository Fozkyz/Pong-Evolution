using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingGunPowerup : Powerup
{
	protected override void Activate(Ball ball)
	{
		if (ball.GetVelocity().x < 0f)
		{
			gameManager.GetComputerPaddle().SetGunProjectileType(ProjectileType.FREEZING);
		}
		else
		{
			gameManager.GetPlayerPaddle().SetGunProjectileType(ProjectileType.FREEZING);
		}
	}
}
