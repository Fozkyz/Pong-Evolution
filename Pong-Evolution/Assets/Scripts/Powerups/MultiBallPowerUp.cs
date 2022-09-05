using UnityEngine;

public class MultiBallPowerUp : Powerup
{
	protected override void Activate(Ball ball)
	{
		ball.Duplicate();

		Destroy(gameObject);
	}
}
