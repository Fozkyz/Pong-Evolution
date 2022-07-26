using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
	private protected GameManager gameManager;

    protected abstract void Activate(Ball ball);

	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();
		if (ball != null)
		{
			Activate(ball);
		}
		Destroy(gameObject);
	}

}
