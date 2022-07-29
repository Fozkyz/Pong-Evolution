using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private ProjectileType projectileType;
	[SerializeField] private float projectileSpeed;

	[SerializeField] private LayerMask collisionMask;

	private void FixedUpdate()
	{
		transform.Translate(transform.right * projectileSpeed * Time.fixedDeltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == gameObject.layer)
		{
			return;
		}
		if (((1 << collision.gameObject.layer) & collisionMask) != 0)
		{
			Paddle paddle = collision.gameObject.GetComponent<Paddle>();
			if (paddle != null)
			{
				switch(projectileType)
				{
					case ProjectileType.FREEZING:
						paddle.ChangePaddleSpeed(-1);
						break;

					case ProjectileType.DOWNSIZING:
						paddle.ChangePaddleSize(-1);
						break;

					default:
						Debug.LogError("Projectile type error");
						break;
				}
			}
			Destroy(gameObject);
		}
	}
}
