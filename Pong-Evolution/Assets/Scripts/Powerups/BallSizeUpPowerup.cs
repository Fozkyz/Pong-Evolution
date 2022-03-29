using UnityEngine;

public class BallSizeUpPowerup : Powerup
{
	protected override void Activate(Ball ball)
	{
		ball.ChangeBallSize(1);
	}
}
