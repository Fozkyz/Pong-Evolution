using UnityEngine;

public class SpeedUpPowerup : Powerup
{
	protected override void Activate(Ball ball)
	{
		if (ball.GetVelocity().x < 0f)
		{
			gameManager.GetComputerPaddle().ChangePaddleSpeed(1);
		}
		else
		{
			gameManager.GetPlayerPaddle().ChangePaddleSpeed(1);
		}
	}
}
