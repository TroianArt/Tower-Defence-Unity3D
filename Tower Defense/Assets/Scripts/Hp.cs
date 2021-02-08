using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour {

	public Text LivesText;
	void Update () {
		if (Player.Lives < 0)
		{
			LivesText.text = "Hp: 0";
		}
		else
		{
			LivesText.text = "Hp: " + Player.Lives.ToString();
		}
	}

}
