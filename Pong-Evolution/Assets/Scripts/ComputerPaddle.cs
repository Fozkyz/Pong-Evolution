using UnityEngine;

public class ComputerPaddle : Paddle
{
	[SerializeField] private Ball focusBall;

	private new void Start()
	{
		base.Start();
		gameManager.SetComputerPaddle(this);
		gameManager.OnLaunchEvent.AddListener(OnLaunch);
		gameManager.OnGamePausedEvent.AddListener(OnGamePaused);
		gameManager.OnGameResumedEvent.AddListener(OnGameResumed);
		gameManager.OnPlayerPaddleHitEvent.AddListener(SetFocusBall);
		gameManager.OnLastBallScoredEvent.AddListener(OnLastBallScored);
	}

	private void FixedUpdate()
	{
		if (focusBall != null && isGameRunning)
		{
			Vector2 direction = Vector2.zero;
			if (focusBall.GetVelocity().x > 0f)
			{
				direction = transform.up * (focusBall.transform.position.y - transform.position.y);
			}
			else
			{
				if (Mathf.Abs(transform.position.y) > .1f)
				{
					direction = -transform.up * transform.position.y;
				}
			}
			rb.AddForce(direction.normalized * speed * Time.fixedDeltaTime);
		}
		if (gun.GetProjectileType() != ProjectileType.NONE && isGameRunning)
        {
			gun.TryShoot();
        }
	}

    public override void OnHit(Ball ball)
    {
		SetFocusBall();
		gameManager.OnComputerPaddleHitEvent.Invoke();
    }

    private void OnLaunch()
    {
		SetFocusBall();
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
		focusBall = null;
	}

	private void SetFocusBall()
    {
		float dist = Mathf.Infinity;
		foreach (Ball ball in gameManager.GetBallList())
        {
			if (ball.GetVelocity().x >= 0f && Mathf.Abs(ball.transform.position.x - transform.position.x) < dist)
            {
				focusBall = ball;
            }
        }
	}
}
