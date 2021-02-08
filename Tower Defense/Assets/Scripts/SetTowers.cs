using UnityEngine;

public class SetTowers : MonoBehaviour {

	public TowerUpdate Tower1;
	public TowerUpdate Tower2;
	public TowerUpdate Tower3;

	SelectManager selectManager;
	void Start ()
	{
		selectManager = SelectManager.Instance;
	}
	public void SelectTower1 ()
	{
		selectManager.SelectTower(Tower1);
	}
	public void SelectTower2()
	{
		selectManager.SelectTower(Tower2);
	}
	public void SelectTower3()
	{
		selectManager.SelectTower(Tower3);
	}

}
