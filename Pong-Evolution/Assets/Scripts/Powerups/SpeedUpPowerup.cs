using UnityEngine;

public class SpeedUpPowerup : Powerup
{
	protected override void Activate(Ball ball)
	{
		if (ball.GetVelocity().x < 0f)
		{
			gameManager.GetComputerPaddle().ChangePaddleSpeed(1);
			Debug.Log("Changing computer paddle speed");
		}
		else
		{
			gameManager.GetPlayerPaddle().ChangePaddleSpeed(1);
			Debug.Log("Changing player paddle speed");
		}
	}
}
