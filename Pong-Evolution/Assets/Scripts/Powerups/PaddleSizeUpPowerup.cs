using UnityEngine;

public class PaddleSizeUpPowerup : Powerup
{
	protected override void Activate(Ball ball)
	{
		if (ball.GetVelocity().x < 0)
		{
			gameManager.GetRightPaddle().ChangePaddleSize(1);
		}
		else
		{
			gameManager.GetLeftPaddle().ChangePaddleSize(1);
		}
	}
}
