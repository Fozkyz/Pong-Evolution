using UnityEngine;

public class Ball : MonoBehaviour
{
	public bool debugMode;
	[SerializeField] private float speed;
	[SerializeField] private Vector2 startVelocity;

	[SerializeField] protected float bounceSpeedMulti;
	[SerializeField] protected float bounceLiftMulti;

	public float velocite;
	private Vector2 direction;


	private void Start()
	{
		if (!debugMode)
		{
			startVelocity.x = Random.value > .5f ? -1f : 1f;
			startVelocity.y = Random.value > .5f ? Random.Range(-1f, -.5f) : Random.Range(.5f, 1f);
			startVelocity.Normalize();
		}
		direction = startVelocity;
	}

	private void FixedUpdate()
	{
		velocite = direction.magnitude;
		if (direction.magnitude > 0)
		{
			transform.Translate(direction * speed * Time.fixedDeltaTime);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 normal = collision.GetContact(0).normal;
		direction = direction - 2 * Vector2.Dot(normal, direction) * normal;
		
		Paddle paddle = collision.gameObject.GetComponent<Paddle>();
		if (paddle != null)
		{
			Vector2 lift = Vector2.Dot(transform.position - paddle.transform.position, paddle.transform.up) * paddle.transform.up * bounceLiftMulti;
			direction = (direction + lift).normalized * direction.magnitude;
			direction *= 1 + bounceSpeedMulti;
		}
	}

	public Vector2 GetVelocity()
	{
		return direction;
	}
}
