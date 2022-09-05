using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public UnityEvent OnLaunchEvent;
	public UnityEvent OnGamePausedEvent;
	public UnityEvent OnGameResumedEvent;
	public UnityEvent OnLastBallScoredEvent;
	public UnityEvent OnPlayerPaddleHitEvent;
	public UnityEvent OnComputerPaddleHitEvent;

	[SerializeField] private TextMeshProUGUI leftScoreText;
	[SerializeField] private TextMeshProUGUI rightScoreText;
	[SerializeField] private List<RawImage> leftPlayerBOScoreUI;
	[SerializeField] private List<RawImage> rightPlayerBOScoreUI;
	[SerializeField] private GameObject pressToStartPanel;
	[SerializeField] private GameObject leftPlayerScoredPanel;
	[SerializeField] private GameObject rightPlayerScoredPanel;
	[SerializeField] private GameObject leftPlayerWinsPanel;
	[SerializeField] private GameObject rightPlayerWinsPanel;
	[SerializeField] private GameObject ballPrefab;

	private PlayerPaddle playerPaddle;
	private ComputerPaddle computerPaddle;

	private int leftPlayerScore;
	private int rightPlayerScore;
	private int leftPlayerBOScore;
	private int rightPlayerBOScore;

	private bool isGameRunning;
	private bool canResumeGame;
	private bool pressToReturnToMenu;

	private List<Ball> ballList;

	void Start()
    {
		isGameRunning = false;
		leftPlayerScore = 0;
		rightPlayerScore = 0;
		leftPlayerBOScore = 0;
		rightPlayerBOScore = 0;
		leftScoreText.text = leftPlayerScore.ToString();
		rightScoreText.text = rightPlayerScore.ToString();
		leftPlayerScoredPanel.SetActive(false);
		rightPlayerScoredPanel.SetActive(false);
		leftPlayerWinsPanel.SetActive(false);
		rightPlayerWinsPanel.SetActive(false);
		canResumeGame = true;
		pressToReturnToMenu = false;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			if (pressToReturnToMenu)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
			}
			else if (!isGameRunning && canResumeGame)
            {
				isGameRunning = true;
				Launch();
            }
		}
    }

    private void Launch()
    {
		canResumeGame = false;
		leftPlayerScore = 0;
		leftScoreText.text = leftPlayerScore.ToString();
		rightPlayerScore = 0;
		rightScoreText.text = rightPlayerScore.ToString();
		pressToStartPanel.SetActive(false);

		ballList = new List<Ball>();
		Ball ball = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity).GetComponent<Ball>();
		AddBallToList(ball);
		OnLaunchEvent.Invoke();
    }

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

	public int GetLeftPlayerScore()
    {
		return leftPlayerScore;
    }

	public int GetRightPlayerScore()
    {
		return rightPlayerScore;
    }

	public void ScorePoint(bool leftPlayerScored, Ball ball)
    {
		if (leftPlayerScored)
        {
            leftPlayerScore++;
            leftScoreText.text = leftPlayerScore.ToString();
        }
		else
        {
			rightPlayerScore++;
			rightScoreText.text = rightPlayerScore.ToString();
		}
		RemoveBallFromList(ball);
		Destroy(ball.gameObject);
		if (ballList.Count <= 0)
		{
			OnLastBallScored();
		}
	}

	public void OnLastBallScored()
    {
		if (leftPlayerScore != rightPlayerScore)
        {
			ScoreBOPoint(leftPlayerScore > rightPlayerScore);
        }
		OnLastBallScoredEvent.Invoke();
		isGameRunning = false;
    }

	private void ScoreBOPoint(bool leftPlayerScored)
    {
		if (leftPlayerScored)
        {
			leftPlayerBOScore++;
			if (leftPlayerBOScore <= leftPlayerBOScoreUI.Count)
            {
				leftPlayerBOScoreUI[leftPlayerBOScore - 1].color = Color.white;
            }
			if (leftPlayerBOScore >= leftPlayerBOScoreUI.Count)
            {
				OnPlayerWins(true);
            }
			else
            {
				StartCoroutine(DisplayPlayerScored(true));
            }
        }
		else
        {
			rightPlayerBOScore++;
			if (rightPlayerBOScore <= rightPlayerBOScoreUI.Count)
			{
				rightPlayerBOScoreUI[rightPlayerBOScore - 1].color = Color.white;
			}
			if (rightPlayerBOScore >= rightPlayerBOScoreUI.Count)
			{
				OnPlayerWins(false);
			}
			else
			{
				StartCoroutine(DisplayPlayerScored(false));
			}
		}
    }

	IEnumerator DisplayPlayerScored(bool leftPlayerScored)
    {
		if (leftPlayerScored)
        {
			leftPlayerScoredPanel.SetActive(true);
        }
		else
        {
			rightPlayerScoredPanel.SetActive(true);
        }
		
		yield return new WaitForSeconds(2.0f);

		leftPlayerScoredPanel.SetActive(false);
		rightPlayerScoredPanel.SetActive(false);

		pressToStartPanel.SetActive(true);
		canResumeGame = true;
    }

	private void OnPlayerWins(bool leftPlayerWins)
    {
		pressToReturnToMenu = true;
		if (leftPlayerWins)
        {
			leftPlayerWinsPanel.SetActive(true);
		}
		else
        {
			rightPlayerWinsPanel.SetActive(true);
		}

	}
}
