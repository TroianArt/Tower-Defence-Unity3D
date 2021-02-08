using UnityEngine;
using UnityEngine.UI;

public class PlatformInterface : MonoBehaviour {

	public GameObject Canvas;
	public Text Cost;
	public Button UpgradeButton;
	public Text Amount;

	private Platform target;

	public void SetTarget (Platform _target)
	{
		target = _target;
		transform.position = target.GetBuildPosition();

		if (!target.IsUpgraded)
		{
			Cost.text=target.TowerUpdate.CostUpgrade.ToString();
			Amount.text = target.TowerUpdate.GetSellAmount().ToString();
			UpgradeButton.interactable = true;
		} else
		{
			Cost.text = "Upgraded";
			Amount.text = target.TowerUpdate.GetSellAmountUpgraded().ToString();
			UpgradeButton.interactable = false;
		}
		Canvas.SetActive(true);
	}

	public void Hide ()
	{
		Canvas.SetActive(false);
	}

	public void Upgrade ()
	{
		target.UpgradeTurret();
		
		SelectManager.Instance.DeselectPlatform();
	}

	public void Sell ()
	{
		target.SellTower();
		SelectManager.Instance.DeselectPlatform();
	}

}
