using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static int Money;
	public int StartMoney = 300;
	public static int Lives;
	public int StartLives = 5;
	public static int Rounds;

	void Start ()
	{
		Money = StartMoney;
		Lives = StartLives;

		Rounds = 0;
	}

}
