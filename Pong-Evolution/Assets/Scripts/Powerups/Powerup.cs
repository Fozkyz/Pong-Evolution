using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    protected abstract void Activate(Ball ball);

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();
		if (ball != null)
		{
			Activate(ball);
		}
	}

}
