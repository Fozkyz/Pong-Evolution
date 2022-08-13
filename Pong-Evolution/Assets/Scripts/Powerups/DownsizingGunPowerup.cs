using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownsizingGunPowerup : Powerup
{
    protected override void Activate(Ball ball)
    {
		if (ball.GetVelocity().x < 0f)
		{
			gameManager.GetComputerPaddle().SetGunProjectileType(ProjectileType.DOWNSIZING);
		}
		else
		{
			gameManager.GetPlayerPaddle().SetGunProjectileType(ProjectileType.DOWNSIZING);
		}
	}
}
