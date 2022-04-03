using UnityEngine;

public class BallSizeDownPowerup : Powerup
{
	protected override void Activate(Ball ball)
	{
		ball.ChangeBallSize(-1);
	}
}