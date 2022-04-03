using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private PlayerPaddle playerPaddle;
	private ComputerPaddle computerPaddle;

	private List<Ball> ballList;

	public PlayerPaddle GetPlayerPaddle()
	{
		return playerPaddle;
	}

	public void SetPlayerPaddle(PlayerPaddle paddle)
	{
		playerPaddle = paddle;
	}

	public ComputerPaddle GetComputerPaddle()
	{
		return computerPaddle;
	}

	public void SetComputerPaddle(ComputerPaddle paddle)
	{
		computerPaddle = paddle;
	}

	public List<Ball> GetBallList()
	{
		return ballList;
	}

	public List<Ball> AddBallToList(Ball ball)
	{
		ballList.Add(ball);
		return ballList;
	}

	public List<Ball> RemoveBallFromList(Ball ball)
	{
		ballList.Remove(ball);
		return ballList;
	}
}
