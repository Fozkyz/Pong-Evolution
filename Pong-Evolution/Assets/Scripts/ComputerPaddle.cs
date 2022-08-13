using UnityEngine;

public class ComputerPaddle : Paddle
{
	[SerializeField] private Ball focusBall;

	private new void Start()
	{
		base.Start();
		gameManager.SetComputerPaddle(this);
		gameManager.OnLaunchEvent.AddListener(OnLaunch);
		gameManager.OnPlayerPaddleHitEvent.AddListener(SetFocusBall);
	}

	private void FixedUpdate()
	{
		if (focusBall != null)
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
		if (gun.GetProjectileType() != ProjectileType.NONE)
        {
			gun.TryShoot();
        }
	}

    public override void OnHit(Ball ball)
    {
		SetFocusBall();
		gameManager.OnComputerPaddleHitEvent.Invoke();
    }

    void OnLaunch()
    {
		SetFocusBall();
    }

	void SetFocusBall()
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
