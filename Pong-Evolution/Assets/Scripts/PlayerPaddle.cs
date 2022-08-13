using UnityEngine;

public class PlayerPaddle : Paddle
{
	[SerializeField] private KeyCode shootKey;

	private Vector2 direction;

	private new void Start()
	{
		base.Start();
		gameManager.SetPlayerPaddle(this);
	}

	private void Update()
	{
		direction = transform.up * Input.GetAxisRaw("Vertical");
		if (Input.GetKey(shootKey) && gun.GetProjectileType() != ProjectileType.NONE)
        {
			gun.TryShoot();
        }
	}

	private void FixedUpdate()
	{
		if (direction.magnitude > 0f)
		{
			rb.velocity = direction * speed * Time.fixedDeltaTime;
			//rb.AddForce(direction * speed * Time.fixedDeltaTime);
		}
	}

    public override void OnHit(Ball ball)
    {
		gameManager.OnPlayerPaddleHitEvent.Invoke();
    }
}
