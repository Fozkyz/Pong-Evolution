using UnityEngine;

public class Paddle : MonoBehaviour
{

	[Header("Paddle Speed")]
	[SerializeField] protected float basePaddleSpeed;
	[SerializeField] protected int minPaddleSpeedLevel;
	[SerializeField] protected int maxPaddleSpeedLevel;
	[SerializeField] protected int defaultPaddleSpeedLevel;
	[SerializeField] protected float paddleSpeedMultiplier;

	[SerializeField] protected float speed;
	protected float speedLevel;
	protected GameManager gameManager;
	protected Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		gameManager = FindObjectOfType<GameManager>();
	}

	protected void Start()
	{
		speedLevel = defaultPaddleSpeedLevel;
		ChangePaddleSpeed(0);
	}

	public void ChangePaddleSpeed(int delta)
	{
		speedLevel = Mathf.Clamp(speedLevel + delta, minPaddleSpeedLevel, maxPaddleSpeedLevel);
		speed = basePaddleSpeed + speedLevel * paddleSpeedMultiplier;
	}
}
