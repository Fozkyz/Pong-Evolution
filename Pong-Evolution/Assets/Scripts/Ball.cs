using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float speed;

	[SerializeField] private Vector2 startVelocity;

	private Vector2 velocity;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = startVelocity * speed;
	}

	private void FixedUpdate()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("hit");
	}
}
