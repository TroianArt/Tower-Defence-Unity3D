using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour {

	public Text MoneyText;
	void Update () {
		MoneyText.text = Player.Money.ToString();
	}
}
