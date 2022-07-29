using UnityEngine;

public class PaddleSizeUpPowerup : Powerup
{
	protected override void Activate(Ball ball)
	{
		if (ball.GetVelocity().x < 0)
		{
			gameManager.GetComputerPaddle().ChangePaddleSize(1);
		}
		else
		{
			gameManager.GetPlayerPaddle().ChangePaddleSize(1);
		}
	}
}
