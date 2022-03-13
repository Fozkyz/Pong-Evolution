using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] protected float speed;

	protected Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
}
