using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    protected abstract void Activate(Ball ball);

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();
		if (ball != null)
		{
			Activate(ball);
		}
	}

}
