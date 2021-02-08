using UnityEngine;

public class SelectManager : MonoBehaviour {

	public static SelectManager Instance;
	public GameObject BuildEffect;
	public GameObject SellEffect;
	public PlatformInterface platformInterface;
	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return Player.Money >= turretToBuild.Cost; } }

	private TowerUpdate turretToBuild;
	private Platform selectedNode;

	void Awake()
	{
		if (Instance != null)
		{
			return;
		}
		Instance = this;
	}
	public void SelectPlatform (Platform node)
	{
		if (selectedNode == node)
		{
			DeselectPlatform();
			return;
		}
		selectedNode = node;
		turretToBuild = null;
		platformInterface.SetTarget(node);
	}
	public void DeselectPlatform()
	{
		selectedNode = null;
		platformInterface.Hide();
	}
	public void SelectTower (TowerUpdate turret)
	{
		turretToBuild = turret;
		DeselectPlatform();
	}
	public TowerUpdate GetTower ()
	{
		return turretToBuild;
	}

}
