using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingGunPowerup : Powerup
{
	protected override void Activate(Ball ball)
	{
		if (ball.GetVelocity().x < 0f)
		{
			gameManager.GetRightPaddle().SetGunProjectileType(ProjectileType.FREEZING);
		}
		else
		{
			gameManager.GetLeftPaddle().SetGunProjectileType(ProjectileType.FREEZING);
		}
	}
}
