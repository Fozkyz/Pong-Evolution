using UnityEngine;

public class ComputerPaddle : Paddle
{
	[SerializeField] private Ball ball;

	private new void Start()
	{
		base.Start();
		gameManager.SetComputerPaddle(this);
	}

	private void FixedUpdate()
	{
		if (ball != null)
		{
			Vector2 direction = Vector2.zero;
			if (ball.GetVelocity().x > 0f)
			{
				direction = transform.up * (ball.transform.position.y - transform.position.y);
			}
			else
			{
				if (Mathf.Abs(transform.position.y) > .1f)
				{
					direction = -transform.up * transform.position.y;
				}
			}
			rb.AddForce(direction.normalized * speed * Time.fixedDeltaTime);
		}
	}
}
