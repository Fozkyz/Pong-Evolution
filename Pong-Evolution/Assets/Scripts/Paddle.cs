using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public abstract class Paddle : MonoBehaviour
{

	[Header("Paddle Speed")]
	[SerializeField] protected float basePaddleSpeed;
	[SerializeField] protected int minPaddleSpeedLevel;
	[SerializeField] protected int maxPaddleSpeedLevel;
	[SerializeField] protected int defaultPaddleSpeedLevel;
	[SerializeField] protected float paddleSpeedMultiplier;

	[Header("Paddle Size")]
	[SerializeField] protected float basePaddleSize;
	[SerializeField] protected int minPaddleSizeLevel;
	[SerializeField] protected int maxPaddleSizeLevel;
	[SerializeField] protected int defaultPaddleSizeLevel;
	[SerializeField] protected float paddleSizeMultiplier;

	[SerializeField] protected Gun gun;

	protected float speed;
	protected int speedLevel;
	protected float paddleSize;
	protected int paddleSizeLevel;

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
		paddleSizeLevel = defaultPaddleSizeLevel;
		ChangePaddleSpeed(0);
		ChangePaddleSize(0);
	}

	public void ChangePaddleSpeed(int delta)
	{
		speedLevel = Mathf.Clamp(speedLevel + delta, minPaddleSpeedLevel, maxPaddleSpeedLevel);
		speed = basePaddleSpeed + speedLevel * paddleSpeedMultiplier;
	}

	public void ChangePaddleSize(int delta)
    {
		paddleSizeLevel = Mathf.Clamp(paddleSizeLevel + delta, minPaddleSizeLevel, maxPaddleSizeLevel);
		paddleSize = basePaddleSize + paddleSizeLevel * paddleSizeMultiplier;
		//transform.localScale = new Vector3(1, 8, 1) * paddleSize;
		transform.localScale = new Vector3(transform.localScale.x, 8 * paddleSize, transform.localScale.z);
	}

	public void SetGunProjectileType(ProjectileType pType)
    {
		gun.SetProjectileType(pType);
    }

	public abstract void OnHit(Ball ball);
}
