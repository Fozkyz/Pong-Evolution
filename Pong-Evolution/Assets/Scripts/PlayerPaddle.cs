using UnityEngine;

public class PlayerPaddle : Paddle
{
	[SerializeField] bool isLeftPlayer;

	[SerializeField] private KeyCode upKey;
	[SerializeField] private KeyCode downKey;
	[SerializeField] private KeyCode shootKey;

	private Vector2 direction;

	private new void Start()
	{
		base.Start();
		if (isLeftPlayer)
		{
			gameManager.SetPlayerPaddle(this);
		}
		else
		{
			gameManager.SetPlayerPaddle2(this);
		}
		gameManager.OnLaunchEvent.AddListener(OnLaunch);
		gameManager.OnGamePausedEvent.AddListener(OnGamePaused);
		gameManager.OnGameResumedEvent.AddListener(OnGameResumed);
		gameManager.OnLastBallScoredEvent.AddListener(OnLastBallScored);
	}

	private void Update()
	{
		direction = Vector2.zero;
		if (Input.GetKey(upKey))
		{
			direction += (Vector2) transform.up;
		}
		if (Input.GetKey(downKey))
		{
			direction -= (Vector2)transform.up;
		}
		//direction = transform.up * Input.GetAxisRaw("Vertical");
		if (Input.GetKey(shootKey) && gun.GetProjectileType() != ProjectileType.NONE && isGameRunning)
        {
			gun.TryShoot();
        }
	}

	private void FixedUpdate()
	{
		if (direction.magnitude > 0f && isGameRunning)
		{
			rb.velocity = direction * speed * Time.fixedDeltaTime;
			//rb.AddForce(direction * speed * Time.fixedDeltaTime);
		}
	}

    public override void OnHit(Ball ball)
    {
		gameManager.OnPlayerPaddleHitEvent.Invoke();
    }

	private void OnLaunch()
	{
		isGameRunning = true;
	}

	private void OnGamePaused()
    {
		isGameRunning = false;
    }

	private void OnGameResumed()
    {
		isGameRunning = true;
    }

	private void OnLastBallScored()
    {
		isGameRunning = false;
    }
}
