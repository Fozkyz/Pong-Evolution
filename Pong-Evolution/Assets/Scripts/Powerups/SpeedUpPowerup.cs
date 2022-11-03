using UnityEngine;

public class SpeedUpPowerup : Powerup
{
	protected override void Activate(Ball ball)
	{
		if (ball.GetVelocity().x < 0f)
		{
			gameManager.GetRightPaddle().ChangePaddleSpeed(1);
		}
		else
		{
			gameManager.GetLeftPaddle().ChangePaddleSpeed(1);
		}
	}
}
