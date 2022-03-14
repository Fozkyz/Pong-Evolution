using UnityEngine;

public class BallSizeUpPowerup : Powerup
{
	private float scaleMultiplier = 2.0f;

	protected override void Activate(Ball ball)
	{
		ball.transform.localScale *= scaleMultiplier;
	}
}
