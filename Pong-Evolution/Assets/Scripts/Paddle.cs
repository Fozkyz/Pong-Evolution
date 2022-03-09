using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] protected float speed;
	[SerializeField] protected float bounceStrength;
	[SerializeField] protected float bounceMulti;

	protected Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();
		if (ball != null)
		{
			Vector2 normal = collision.GetContact(0).normal;
			Vector2 orientation = Vector2.Dot(ball.transform.position - transform.position, transform.up) * transform.up;
			ball.AddForce(-normal * bounceStrength + orientation * bounceMulti);
		}
	}
}
