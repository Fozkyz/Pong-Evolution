using UnityEngine;

public class PlayerPaddle : Paddle
{
	private Vector2 direction;

	private void Update()
	{
		direction = transform.up * Input.GetAxisRaw("Vertical");
	}

	private void FixedUpdate()
	{
		if (direction.magnitude > 0f)
		{
			rb.velocity = direction * speed * Time.fixedDeltaTime;
			//rb.AddForce(direction * speed * Time.fixedDeltaTime);
		}
	}
}
