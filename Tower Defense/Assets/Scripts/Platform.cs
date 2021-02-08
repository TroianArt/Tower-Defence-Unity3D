using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour {

	public Color HoverColor;
	public Color NotHaveMoneyColor;
    public Vector3 Position;
	public GameObject Tower;
	public TowerUpdate TowerUpdate;
	public bool IsUpgraded = false;

	private Renderer rend;
	private Color startColor;
	private SelectManager buildManager;
	void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = SelectManager.Instance;
    }
	public Vector3 GetBuildPosition ()
	{
		return transform.position + Position;
	}
	void OnMouseDown ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		if (Tower != null)
		{
			buildManager.SelectPlatform(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;
		PutTower(buildManager.GetTower());
	}

	void PutTower (TowerUpdate blueprint)
	{
		if (Player.Money < blueprint.Cost)
		{
			return;
		}
		Player.Money -= blueprint.Cost;
		GameObject _turret = (GameObject)Instantiate(blueprint.Prefab, GetBuildPosition(), Quaternion.identity);
		Tower = _turret;
		TowerUpdate = blueprint;
		GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
	}

	public void UpgradeTurret ()
	{
		if (Player.Money < TowerUpdate.CostUpgrade)
		{
			return;
		}
		Player.Money -= TowerUpdate.CostUpgrade;
		Destroy(Tower);
		GameObject tower = (GameObject)Instantiate(TowerUpdate.PrefabUpgraded, GetBuildPosition(), Quaternion.identity);
		Tower = tower;
		GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
		IsUpgraded = true;

	}

	public void SellTower ()
	{
        if (IsUpgraded)
        {
			Player.Money += TowerUpdate.GetSellAmountUpgraded();
        }
        else
        {
			Player.Money += TowerUpdate.GetSellAmount();
		}
		GameObject effect = (GameObject)Instantiate(buildManager.SellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
		Destroy(Tower);
		TowerUpdate = null;
	}

	void OnMouseEnter ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		if (!buildManager.CanBuild)
			return;
		if (buildManager.HasMoney)
		{
			rend.material.color = HoverColor;
		} 
		else
		{
			rend.material.color = NotHaveMoneyColor;
		}
	}
	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }
}
