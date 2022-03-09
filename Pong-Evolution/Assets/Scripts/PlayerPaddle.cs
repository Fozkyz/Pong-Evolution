using UnityEngine;

public class PlayerPaddle : Paddle
{
	private Vector2 direction;

	private void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			direction = transform.up;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			direction = -transform.up;
		}
		else
		{
			direction = Vector2.zero;
		}
	}

	private void FixedUpdate()
	{
		if (direction.magnitude > 0f)
		{
			rb.AddForce(direction * speed * Time.fixedDeltaTime);
		}
	}
}
