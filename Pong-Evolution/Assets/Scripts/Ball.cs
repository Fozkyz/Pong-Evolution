using UnityEngine;

public class Ball : MonoBehaviour
{
	public bool debugMode;
	[SerializeField] private float speed;
	[SerializeField] private Vector2 startVelocity;

	public float velocite;

	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		if (!debugMode)
		{
			startVelocity.x = Random.value > .5f ? -1f : 1f;
			startVelocity.y = Random.value > .5f ? Random.Range(-1f, -.5f) : Random.Range(.5f, 1f);
			startVelocity.Normalize();
		}
		AddForce(startVelocity * speed);
	}

	private void FixedUpdate()
	{
		velocite = rb.velocity.magnitude;
	}

	public void AddForce(Vector2 force)
	{
		rb.AddForce(force);
	}

	public Vector2 GetVelocity()
	{
		return rb.velocity;
	}
}
