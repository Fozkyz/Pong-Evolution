using UnityEngine;

public class ComputerPaddle : Paddle
{
	[SerializeField] private Ball ball;

	private void FixedUpdate()
	{
		if (ball != null)
		{
			Vector2 direction;
			if (ball.GetVelocity().x > 0f)
			{
				direction = transform.up * (ball.transform.position.y - transform.position.y);
			}
			else
			{
				direction = -transform.up * transform.position.y;
			}
			rb.AddForce(direction.normalized * speed * Time.fixedDeltaTime);
		}
	}
}
