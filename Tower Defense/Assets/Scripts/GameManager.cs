using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject GameOver;
	public GameObject Win;

	void Start ()
	{
		GameIsOver = false;
	}

	void Update () {
		if (GameIsOver)
			return;

		if (Player.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame ()
	{
		GameIsOver = true;
		GameOver.SetActive(true);
	}

	public void WinLevel ()
	{
		GameIsOver = true;
		Win.SetActive(true);
	}

}
