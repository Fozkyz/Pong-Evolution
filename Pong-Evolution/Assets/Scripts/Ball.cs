using UnityEngine;

public class Ball : MonoBehaviour
{
	public bool debugMode;
	[SerializeField] private float speed;
	[SerializeField] private Vector2 startVelocity;
	[SerializeField] private int startSide;

	[Header("Ball bounce")]
	[SerializeField] protected float bounceSpeedMulti;
	[SerializeField] protected float bounceLiftMulti;
	[SerializeField] private LayerMask ScoreMask;

	[Header("Ball Size")]
	[SerializeField] protected float baseBallSize;
	[SerializeField] protected int minBallSizeLevel;
	[SerializeField] protected int maxBallSizeLevel;
	[SerializeField] protected int defaultBallSizeLevel;
	[SerializeField] protected float ballSizeMultiplier;

	private Vector2 direction;

	private float ballSize;
	private int ballSizeLevel;

	private GameManager gameManager;

	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
		if (!debugMode)
		{
			startVelocity.x = startSide != 0 ? startSide : Random.value > .5f ? -1f : 1f;
			startVelocity.y = Random.value > .5f ? Random.Range(-1f, -.5f) : Random.Range(.5f, 1f);
			startVelocity.Normalize();
		}
		direction = startVelocity;

		ballSizeLevel = defaultBallSizeLevel;
		ChangeBallSize(0);
		
	}

	private void FixedUpdate()
	{
		if (direction.magnitude > 0)
		{
			transform.Translate(direction * speed * Time.fixedDeltaTime);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == gameObject.layer)
		{
			return;
		}
        if (((1<<collision.gameObject.layer) & ScoreMask) != 0)
		{
			gameManager.ScorePoint(direction.x > 0, this);
        }

		Vector2 normal = collision.GetContact(0).normal;
		direction = direction - 2 * Vector2.Dot(normal, direction) * normal;
		
		Paddle paddle = collision.gameObject.GetComponent<Paddle>();
		if (paddle != null)
		{
			Vector2 lift = Vector2.Dot(transform.position - paddle.transform.position, paddle.transform.up) * paddle.transform.up * bounceLiftMulti;
			direction = (direction + lift).normalized * direction.magnitude;
			direction *= 1 + bounceSpeedMulti;
			paddle.OnHit(this);
		}
	}

	public Vector2 GetVelocity()
	{
		return direction;
	}

	public void ChangeBallSize(int delta)
	{
		ballSizeLevel = Mathf.Clamp(ballSizeLevel + delta, minBallSizeLevel, maxBallSizeLevel);
		ballSize = baseBallSize + ballSizeLevel * ballSizeMultiplier;
		transform.localScale = Vector3.one * ballSize;
	}

	public void Duplicate()
	{
		GameObject newBall = Instantiate(gameObject, transform.position, Quaternion.identity);
		Ball ballComponent = newBall.GetComponent<Ball>();
		ballComponent.debugMode = false;
		ballComponent.startSide = (int)Mathf.Sign(direction.x);
		ballComponent.defaultBallSizeLevel = ballSizeLevel;
		if (gameManager != null)
        {
			gameManager.AddBallToList(ballComponent);
        }
	}
}
