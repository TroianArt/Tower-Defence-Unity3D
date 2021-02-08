using UnityEngine;
using System.Collections;

[System.Serializable]
public class TowerUpdate {

	public GameObject Prefab;
	public int Cost;
	public GameObject PrefabUpgraded;
	public int CostUpgrade;
	public int GetSellAmount ()
	{
		return Cost / 2;
	}
	public int GetSellAmountUpgraded()
	{
		return (Cost+CostUpgrade) / 2;
	}

}
